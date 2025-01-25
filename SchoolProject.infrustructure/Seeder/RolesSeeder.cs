using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.infrustructure.Seeder;

public static class RolesSeeder
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = await roleManager.Roles.CountAsync();
        if (roles<=0)
        {
           await roleManager.CreateAsync(
               new IdentityRole{Name = "Admin"}
           );
           await roleManager.CreateAsync(
               new IdentityRole{Name = "User"}
           );
           
        }

    }
}