using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Command.Model;

public class UpdateUserRolesCommand: IRequest<Response<string>>
{
    public string UserId { get; set; }
    public List<Queries.Response.UserRoles> Roles { get; set; } 
}
