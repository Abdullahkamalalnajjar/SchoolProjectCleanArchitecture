using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Command.Model
{
    public class AddUserCommand: IRequest<Response<string>>
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

    }
}
