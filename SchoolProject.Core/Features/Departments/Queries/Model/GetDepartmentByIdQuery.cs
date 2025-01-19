using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Responses;

namespace SchoolProject.Core.Features.Departments.Queries;

public class GetDepartmentByIdQuery(int id) : IRequest<Response<GetDepartmentByIdResponse>>
{

    public int Id { get; set; } = id;
}