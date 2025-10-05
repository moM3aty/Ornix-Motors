using Microsoft.AspNetCore.Identity;
using OrnixMotors.Models;

namespace OrnixMotors.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Create admin role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create admin user if it doesn't exist
            var adminUser = await userManager.FindByEmailAsync("admin@ornix.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "YourUser",
                    Email = "yourE-mail",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "yourPassword");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
