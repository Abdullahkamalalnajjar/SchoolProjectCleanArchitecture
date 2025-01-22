using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Model;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;
using System.Linq.Expressions;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler
        : ResponseHandler,
            IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
            IRequestHandler<GetSingleStudentQuery, Response<GetSingleStudentResponse>>,
            IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public StudentHandler(
            IStudentService studentService,
            IMapper mapper,
            IStringLocalizer<SharedResources> localizer):base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListAsync();
            var studentsMapper = _mapper.Map<List<GetStudentListResponse>>(students);
            return Success(studentsMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetSingleStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIDAsync(request.StudentId);
            if (student is null) return NotFound<GetSingleStudentResponse>();
            var studentMapper = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            // Apply filtering and ordering
            var filteredStudents = _studentService.FilterStudentPaginatedQuerable(request.Ordering, request.Search);

            // Map filtered students to the response type
            var studentsMapper = _mapper.ProjectTo<GetStudentPaginatedListResponse>(filteredStudents);

            // Paginate the mapped result
            var paginatedList = await studentsMapper.ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }

    }
}
