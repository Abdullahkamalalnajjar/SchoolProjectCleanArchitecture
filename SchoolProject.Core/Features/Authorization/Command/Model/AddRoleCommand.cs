using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authorization.Command.Model;

public class AddRoleCommand:IRequest<Response<string>>
{
    public string RoleName { get; set; }
} 