namespace SchoolProject.Core.Features.Authorization.Queries.Response;

public class MangeUserRolesRequest
{
    public string UserId { get; set; }
    public List<UserRoles> UserRoles { get; set; }
}

public class UserRoles
{
    public string Id { get; set; }
    public string RoleName { get; set; }
    public bool HasRole { get; set; }
} 