using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Responses;

namespace SchoolProject.Core.Features.Departments.Queries.Model
{
    public class GetDepartmentListQuery : IRequest<Response<List<GetDepartmentListResponse>>>
    {

    }
}
