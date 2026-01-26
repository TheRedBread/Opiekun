using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Opiekun.Data;

namespace Opiekun.Services;

public class SeedService
{

    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OpiekunDbContext>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

        try
        {
            // Ensure the database is ready
            logger.LogInformation("Ensuring the database is created.");
            await context.Database.EnsureCreatedAsync();

            // Add roles
            logger.LogInformation("Seeding roles.");
            await AddRoleAsync(roleManager, "Admin");
            await AddRoleAsync(roleManager, "Support");
            await AddRoleAsync(roleManager, "User");

            // Add admin user
            logger.LogInformation("Seeding admin user.");

            await AddUserAsync(logger, userManager, "admin@dtemplars.com", "Example123#", "Admin");
            await AddUserAsync(logger, userManager, "support@dtemplars.com", "Example123#", "Support");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");

        }

    }

    private static async Task AddUserAsync(ILogger<SeedService> logger, UserManager<IdentityUser> userManager, string email, string password, string role)
    {

        if (await userManager.FindByEmailAsync(email) != null)
        {
            logger.LogInformation("User is already in DB");
            return;
        }

        var adminUser = new IdentityUser
        {
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await userManager.CreateAsync(adminUser, password);
        if (result.Succeeded)
        {
            logger.LogInformation("Assigning Admin role to the admin user.");
            await userManager.AddToRoleAsync(adminUser, role);
        }
        else
        {
            logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }



    private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

}
