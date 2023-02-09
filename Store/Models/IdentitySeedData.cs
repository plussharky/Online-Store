using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = "Admin", Surname="Admin"};
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
