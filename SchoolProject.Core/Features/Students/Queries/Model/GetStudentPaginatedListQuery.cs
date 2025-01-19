using MediatR;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Model;

public class GetStudentPaginatedListQuery:IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }

    public StudentOrderingEnum Ordering { get; set; }
    
}