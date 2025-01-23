using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Model;

public class SignInCommand: IRequest<Response<JwtAuthResult>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}