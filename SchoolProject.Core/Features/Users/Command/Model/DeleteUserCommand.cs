using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Command.Model;

public class DeleteUserCommand:IRequest<Response<string>>
{
    public string Id { get; set; }
}