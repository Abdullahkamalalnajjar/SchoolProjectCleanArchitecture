using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Model
{
    public class EditDepartmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
