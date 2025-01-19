using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

public class GetDepartmentPaginatedListQuery : IRequest<PaginatedResult<GetDepartmentPaginatedListResponse>>
{
    public GetDepartmentPaginatedListQuery() { } // Parameterless constructor for model binding

    public GetDepartmentPaginatedListQuery(int pageNumber, int pageSize, string? search, DepartmentOrderingEnum? departmentOrderingEnum)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        DepartmentOrderingEnum = departmentOrderingEnum;
        Search = search;

    }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
    public DepartmentOrderingEnum? DepartmentOrderingEnum { get; set; }
}
