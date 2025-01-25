using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.Authorization.Queries.Response;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Implementation;

public class AuthorizationService: IAuthorizationService 
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthorizationService(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<string> AddRoleAsync(string roleName)
    {
       var role = new IdentityRole(roleName);
       await _roleManager.CreateAsync(role);
       return "Added";
    }

    public async Task<MangeUserRolesRequest> MangeUserRolesDataAsync(AppUser user)
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var userRoles = await _userManager.GetRolesAsync(user);
        var response = new MangeUserRolesRequest();
        var userroles = new List<UserRoles>(); 
        response.UserId= user.Id;
        foreach (var role in roles)
        {
            var userrole = new UserRoles();
            userrole.Id = role.Id;
            userrole.RoleName = role.Name;
            if (userRoles.Contains(role.Name))
            {
                userrole.HasRole = true;
            }
            else
            {
                userrole.HasRole = false;   
            }
            userroles.Add(userrole);
        }
        response.UserRoles = userroles;
        return response;
        
    }

    public async Task<string> UpdateUserRolesAsync(MangeUserRolesRequest request)
    {
       var user = await _userManager.FindByIdAsync(request.UserId);
       var roles = await _userManager.GetRolesAsync(user!);
       var removeOldRoles = await _userManager.RemoveFromRolesAsync(user!, roles);
       if(!removeOldRoles.Succeeded) return "FailedToRemoveRoles";
       var selectedRole = request.UserRoles.Where(x=>x.HasRole==true).Select(x=>x.RoleName).ToList();   
       var addNewRolesResult =await _userManager.AddToRolesAsync(user!,selectedRole);
       if(!addNewRolesResult.Succeeded) return "FailedToAddNewRoles";
       return "Success";
    }

    public Task<bool> IsExistRole(string roleName)
    {
        return _roleManager.RoleExistsAsync(roleName);
    }
}