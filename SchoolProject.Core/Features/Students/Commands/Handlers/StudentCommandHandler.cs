using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                       IRequestHandler<AddStudentCommand, Response<string>>,
                                       IRequestHandler<EditStudentCommand, Response<string>>,
                                       IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #region Constractor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper,IStringLocalizer<SharedResources> localizer) : base(localizer) 
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //Make Mapping Between AddStudent and Student
            var studentMapping = _mapper.Map<Student>(request);
            // Add Student
            var student = await _studentService.AddStudentAsync(studentMapping);

            if (student == "Created") return Created("");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check student exist or no exist
            var student = await _studentService.GetStudentByIDAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");
            // make mapping between sudent and edit
            var studentmapper = _mapper.Map<Student>(request);
            // make edit 
            var result = await _studentService.EditStudentAsync(studentmapper);
            //response
            if (result == "Updated") return Updated($"Edit Successfully : {studentmapper.Id}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check student exist or no 
            var student = await _studentService.GetStudentByIDAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");
            await _studentService.DeleteStudentAsync(student);
            return Deleted<string>();
        }
    }
}
