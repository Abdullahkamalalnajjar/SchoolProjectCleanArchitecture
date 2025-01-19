using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Response;

namespace SchoolProject.Core.Features.Students.Queries.Model
{
    public class GetSingleStudentQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int StudentId { get; set; }

        public GetSingleStudentQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
