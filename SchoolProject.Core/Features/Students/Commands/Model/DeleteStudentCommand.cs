using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Model
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
