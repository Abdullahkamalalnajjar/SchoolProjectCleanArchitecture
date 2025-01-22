using SchoolProject.Core.Features.Users.Queries.Response;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users;

public partial class UserProfile
{
    public void Mapping_GetPaginatedListQueryMapping()
    {
        CreateMap<AppUser, GetUserPaginatedListResponse>();
    }
}