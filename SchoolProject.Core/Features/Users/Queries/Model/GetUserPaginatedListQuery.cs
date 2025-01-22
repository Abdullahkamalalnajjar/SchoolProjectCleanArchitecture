using MediatR;
using SchoolProject.Core.Features.Users.Queries.Response;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Model;

public class GetUserPaginatedListQuery : IRequest<PaginatedResult<GetUserPaginatedListResponse>>
{
    public GetUserPaginatedListQuery()
    {
        
    }
    public GetUserPaginatedListQuery(int pageNumber, int pageSize)
    {
        PageNumber= pageNumber;
        PageSize= pageSize;
    }
    public int PageNumber { get; set; } 
    public int PageSize { get; set; } 
}