using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Response;

namespace SchoolProject.Core.Features.Authorization.Queries.Model;

public class MangeUserRolesQuery(string userId) : IRequest<Response<MangeUserRolesRequest>>
{
    public string UserId { get; set; } = userId;
}