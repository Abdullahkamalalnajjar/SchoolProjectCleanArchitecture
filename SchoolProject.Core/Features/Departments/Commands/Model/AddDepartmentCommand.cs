using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Model
{
    public class AddDepartmentCommand(string name) : IRequest<Response<string>>
    {
        public string Name { get; set; } = name;
    }
}
