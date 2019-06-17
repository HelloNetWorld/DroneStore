using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DroneStore.Web.Identity
{
    public static class IdentitySettings
    {
        public static async Task SeedAccounts(IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAndUser("Admin", userManager, roleManager, configuration);
            await SeedRoleAndUser("User", userManager, roleManager, configuration);
        }

        private static async Task SeedRoleAndUser(string userConfigType, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            string username = configuration[$"{userConfigType}:Name"];
            string email = configuration[$"{userConfigType}:Email"];
            string password = configuration[$"{userConfigType}:Password"];
            string role = configuration[$"{userConfigType}:Role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                var user = new AppUser
                {
                    UserName = username,
                    Email = email
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
