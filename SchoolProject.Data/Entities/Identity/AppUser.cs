using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity;

public class AppUser : IdentityUser
{
    public string? Address { get; set; }
    public string? FullName { get; set; }
    public string? Country { get; set; }
    public string Password { get; set; }
    public virtual ICollection<UserRefreshToken> RefreshTokens { get; set; }
}