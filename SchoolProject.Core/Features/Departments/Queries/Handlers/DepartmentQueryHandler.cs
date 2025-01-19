using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Model;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstract;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers;

public class DepartmentQueryHandler(IStringLocalizer<SharedResources> localizer, IDepartmentService _departmentService, IStudentService _studentService, IMapper mapper) : ResponseHandler(localizer),
    IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
    IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListResponse>>>,
    IRequestHandler<GetDepartmentPaginatedListQuery, PaginatedResult<GetDepartmentPaginatedListResponse>>
{
    private readonly IMapper _mapper = mapper;

    public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        //get service byid
        var department = await _departmentService.GetDepartmentByIdAsync(request.Id);
        //check 
        if (department is null) return NotFound<GetDepartmentByIdResponse>();
        //mapping
        var departmentMapping = _mapper.Map<GetDepartmentByIdResponse>(department);
        //response
        return Success(departmentMapping);
    }

    public Task<PaginatedResult<GetDepartmentPaginatedListResponse>> Handle(GetDepartmentPaginatedListQuery request, CancellationToken cancellationToken)
    {
        //make expression
        Expression<Func<Department, GetDepartmentPaginatedListResponse>> expression = e => new GetDepartmentPaginatedListResponse(
            e.Id,
            e.Name,
            e.Students.Select(s => new StudentResponse(s.Id, s.Name, s.Address, s.Phone, s.Department.Name)).ToList(),
            e.DepartmentSubjects.Select(s => new SubjectResponse(s.Subjects.Id, s.Subjects.SubjectName)).ToList(),
            e.Instructors.Select(s => new InstructorResponse(s.Id, s.Name, s.Salary, s.Position)).ToList());

        //get queryable from service
        var queryable = _departmentService.FilterWithPaginationDepartmentQueryable(request.Search, request.DepartmentOrderingEnum);
        var paginatedResult = queryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedResult;

    }
    public async Task<Response<List<GetDepartmentListResponse>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
    {
        var departmentList = await _departmentService.GetDepartmentListAsync();
        //Mapping
        var departmentMapping = _mapper.Map<List<GetDepartmentListResponse>>(departmentList);

        return Success(departmentMapping);
    }


}