using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Abstract;

public interface IAuthenticationService
{
    public Task<string> GetTokenAsync(AppUser user);
}