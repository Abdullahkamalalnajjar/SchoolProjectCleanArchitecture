using AutoMapper;
using SchoolProject.Core.Features.Users.Command.Model;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.Users;

public partial class UserProfile 
{
    public void Mapping_EditUserCommandMapping()
    {
        CreateMap<EditUserCommand, AppUser>()
            .ForMember(i=>i.Id,opt=>opt.Ignore());
    }
}