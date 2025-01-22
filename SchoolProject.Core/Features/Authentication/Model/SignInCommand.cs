using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Model;

public class SignInCommand: IRequest<Response<string>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}