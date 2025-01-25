using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Abstract;

public interface IAuthorizationService
{
    public Task<string> AddRoleAsync(string roleName);
    public Task<bool> IsExistRole(string roleName);

    public Task<MangeUserRolesRequest> MangeUserRolesDataAsync(AppUser user);
    public Task<string> UpdateUserRolesAsync(MangeUserRolesRequest request);
}