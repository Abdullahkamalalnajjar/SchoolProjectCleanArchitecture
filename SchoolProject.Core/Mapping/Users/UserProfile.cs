using AutoMapper;

namespace SchoolProject.Core.Mapping.Users;

public partial class UserProfile:Profile
{
    public UserProfile()
    {
        Mapping_AddUserCommandMapping();
        Mapping_EditUserCommandMapping();
        Mapping_GetPaginatedListQueryMapping();
        Mapping_GetUserByIdQuery();
    }
}