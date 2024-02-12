using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KoboldPainting.Data.SeedingUsers;
using KoboldPainting.Models;
using KoboldPainting.Areas.Identity.Data;
// using KoboldPainting.Areas.Identity.Data;


namespace KoboldPainting.Utilities;
[ExcludeFromCodeCoverage]
public class SeedUsers
{
    /// <summary>
    /// Initialize seed data for users.  Creates users for login using Identity and also application users.  One password
    /// is used for all accounts.
    /// </summary>
    /// <param name="serviceProvider">The fully configured service provider for this app that can provide a UserManager and the applications dbcontext</param>
    /// <param name="seedData">Array of seed data holding all the attributes needed to create the user objects</param>
    /// <param name="testUserPw">Password for all seed accounts</param>
    /// <returns></returns>
    public static async Task Initialize(IServiceProvider serviceProvider, UserInfoData[] seedData, string testUserPw)
    {
        try
        {
            // Get our application db context
            //   For later reference -- this uses the "Service Locator anti-pattern", not usually a good pattern
            //   but unavoidable here
            using (var context = new KoboldPaintingDbContext(serviceProvider.GetRequiredService<DbContextOptions<KoboldPaintingDbContext>>()))
            {
                // Get the Identity user manager
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                foreach (var u in seedData)
                {
                    // Ensure this user exists or is newly created (Email is used for username since that is the default in Register and Login -- change those and then use username here if you want it different than email
                    var identityID = await EnsureUser(userManager, testUserPw, u.Email, u.Email, true, u.FirstName, u.LastName);
                    // Create a new Person if this one doesn't already exist
                    KoboldUser kolboldUser = new KoboldUser
                    {
                        AspNetUserId = identityID,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                    };

                    bool checkIfKoboldUserExists = context.KoboldUsers.Any(x => x.AspNetUserId == identityID);
                    if (!checkIfKoboldUserExists)
                    {
                        // Doesn't already exist, so add a new user
                        context.Add(kolboldUser);
                        var koboldUserPaintRecipes = new PaintRecipe()
                        {
                            KoboldUserId = kolboldUser.Id,
                            KoboldUser = kolboldUser,
                            RecipeName = u.FirstName + " " + u.LastName +  " Test Recipe",
                            Description = "Test Description",
                        };
                        context.Add(koboldUserPaintRecipes);

                        //! Causes error
                        // ! "Unable to track an instance of type 'WantedPaint' because it does not have a primary key. Only entity types with a primary key may be tracked."
                        // var koboldUserWantedPaint = new WantedPaint()
                        // {
                        //     KoboldUserId = kolboldUser.Id,
                        //     KoboldUser = kolboldUser,
                        //     PaintId = 1
                        // };
                        // context.Add(koboldUserWantedPaint);

                        // var koboldUserOwnedPaint = new OwnedPaint()
                        // {
                        //     KoboldUserId = kolboldUser.Id,
                        //     KoboldUser = kolboldUser
                        // };
                        // context.Add(koboldUserOwnedPaint);
                        // var koboldUserRefillPaint = new RefillPaint()
                        // {
                        //     KoboldUserId = kolboldUser.Id,
                        //     KoboldUser = kolboldUser
                        // };
                        // context.Add(koboldUserRefillPaint);
                    }
                    await context.SaveChangesAsync();                
            }
        }
        }
        catch (InvalidOperationException ex)
        {
            // Thrown if there is no service of the type requested from the service provider
            // Catch it (and don't throw the exception below) if you don't want it to fail (5xx status code)
            throw new Exception("Failed to initialize user seed data, service provider did not have the correct service");
}
    }

    /// <summary>
    /// Helper method to ensure that the Identity user exists or has been newly created.  Modified from
    /// <a href="https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-5.0#create-the-test-accounts-and-update-the-contacts">create the test accounts and update the contacts (in Contoso University example)</a>
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="password"></param>
    /// <param name="username"></param>
    /// <param name="email"></param>
    /// <param name="emailConfirmed"></param>
    /// <returns>The Identity ID of the user</returns>
    private static async Task<string> EnsureUser(UserManager<ApplicationUser> userManager, string password, string username
                                                , string email, bool emailConfirmed, string firstName, string lastName)
{
    var user = await userManager.FindByNameAsync(username);
    if (user == null)
    {
        user = new ApplicationUser()
        {
            UserName = username,
            Email = email,
            EmailConfirmed = emailConfirmed,
            FirstName = firstName,
            LastName = lastName
        };
        await userManager.CreateAsync(user, password);
    }
    if (user == null)
    {
        throw new Exception("The password is probably not strong enough!");
    }

    return user.Id;
}
}
