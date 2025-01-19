using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Departments.Commands.Model
{
    public class DeleteDepartmentCommand(int id) : IRequest<Response<string>>
    {

        public int Id { get; set; } = id;
    }
}
