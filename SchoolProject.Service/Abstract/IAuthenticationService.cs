using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstract;

public interface IAuthenticationService
{
    public Task<JwtAuthResult> GetTokenAsync(AppUser user);
}