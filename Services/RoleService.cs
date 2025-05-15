using abronalPortal.Data;
using abronalPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace abronalPortal.Services
{
    public class RoleService
    {
        public static async Task RoleDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AbronalDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(); 
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Users>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<RoleService>>();

            try
            {
                logger.LogInformation("Ensuring database is created...");
                await context.Database.EnsureCreatedAsync();

                logger.LogInformation("Seeding roles...");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                var adminEmail = "admin@abronal.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Users
                    {
                        UserName = "evaluator",
                        Email = adminEmail,
                        Fullname = "Application Evaluator",
                        ProfilePicturePath = "https://abronal.com/website/img/favicon.png",
                        NormalizedUserName = adminEmail.ToUpper(),
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),                        
                    };
                    var result = await userManager.CreateAsync(adminUser, "abronalApply2025");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Admin user created successfully.");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.CreateAsync(new IdentityRole(roleName));
            if(!role.Succeeded)
            {
                throw new Exception($"Failed to create role {roleName}: {string.Join(", ", role.Errors.Select(e => e.Description))}");
            }
            
        }
    }
}