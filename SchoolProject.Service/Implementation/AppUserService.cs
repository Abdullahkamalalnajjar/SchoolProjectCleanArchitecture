using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Service.Implementation;

public class AppUserService:IAppUserService
{
    private readonly UserManager<AppUser> _userManager;

    public AppUserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<bool> IsEmailExistExcludeSelf(string id, string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email & u.Id != id);
        return user != null;
    }
}