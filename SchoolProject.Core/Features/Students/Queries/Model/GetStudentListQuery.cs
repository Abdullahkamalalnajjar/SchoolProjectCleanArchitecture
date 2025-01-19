using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Response;
namespace SchoolProject.Core.Features.Students.Queries.Model
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
