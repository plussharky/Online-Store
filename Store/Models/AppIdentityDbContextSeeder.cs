using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Store.Models
{
    public class AppIdentityDbContextSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser { UserName = "demouser@demouser.com", Email = "demouser@demouser.com" };
            if ((await userManager.FindByEmailAsync("demouser@demouser.com")) == null)
            {
                await userManager.CreateAsync(defaultUser, "Pass@word1");
                var roleName = "Admin";
                await roleManager.CreateAsync(new IdentityRole(roleName));
                await userManager.AddToRoleAsync(defaultUser, roleName);
            }
        }
    }
}
