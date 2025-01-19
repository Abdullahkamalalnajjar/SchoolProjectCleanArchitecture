using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandlers : ResponseHandler,
        IRequestHandler<AddDepartmentCommand, Response<string>>,
        IRequestHandler<DeleteDepartmentCommand, Response<string>>,
        IRequestHandler<EditDepartmentCommand, Response<string>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentCommandHandlers(IDepartmentService departmentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Mapping AddDepartment = > Department
            var departmentMapper = _mapper.Map<Department>(request);
            //Add
            var departmentResult = await _departmentService.AddDepartmentAsync(departmentMapper);
            //response
            if (departmentResult == "Existing") return new Response<string>();
            return Created("");

        }

        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            //check department exist or no 
            var department = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (department == null) return NotFound<string>();
            await _departmentService.DeleteDepartmentAsync(department);
            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            //Check department exist or no 
            var check = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (check is null) return NotFound<string>();
            var department = _mapper.Map<Department>(request);
            var result = await _departmentService.EditDepartmentAsync(department);
            if (result == "Updated") return Updated(result);
            return UnprocessableEntity<string>();
        }
    }
}
