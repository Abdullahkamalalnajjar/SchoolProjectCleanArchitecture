using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.Response;

namespace SchoolProject.Core.Features.Users.Queries.Model;

public class GetUserByIdQuery:IRequest<Response<GetUserByIdResponse>>
{
    public string UserId { get; set; }
}