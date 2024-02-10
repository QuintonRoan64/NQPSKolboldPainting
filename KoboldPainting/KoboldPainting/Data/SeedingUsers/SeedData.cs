using System.Diagnostics.CodeAnalysis;
using Humanizer;
using KoboldPainting.Models;

namespace KoboldPainting.Data.SeedingUsers;

/// <summary>
/// Helper class to hold information we need for users in our project databases.
/// </summary>
[ExcludeFromCodeCoverage]
public class UserInfoData
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<PaintRecipe> UserPaintRecipes { get; set; } = new List<PaintRecipe>()
    {
        // new PaintRecipe
        // {
        //     RecipeName = "Test Recipe",
        //     Description = "This is a test recipe",
        //     KolboldUserId = 1
        // }
    };
    public List<OwnedPaint> UserOwnedPaints { get; set; } = new List<OwnedPaint>()
    {
        // new OwnedPaint
        // {
        //     PaintId = 1,
        //     KolboldUserId = 1
        // }
    };
    public List<WantedPaint> UserWantedPaints { get; set; } = new List<WantedPaint>()
    {
        // new WantedPaint
        // {
        //     PaintId = 1,
        //     KolboldUserId = 1
        // }
    };
    public List<RefillPaint> UserRefillPaints { get; set; } = new List<RefillPaint>()
    {
        // new RefillPaint
        // {
        //     PaintId = 1,
        //     KolboldUserId = 1
        // }
    };
    public List<Tutorial> UserTutorials { get; set; } = new List<Tutorial>()
    {
        // new Tutorial
        // {
        //     KolboldUserId = 1,
        //     VideoUrl = "SomeURL"
        // }
    };
    // {

    // };
}
[ExcludeFromCodeCoverage]
public class SeedData
{
    /// <summary>
    /// Data to be used to see the KoboldUsers and ASPNetUsers Tables
    /// </summary>
    public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
    {
            new UserInfoData { Email = "knott@example.com", FirstName = "Talia", LastName = "Knott"//,
                            //    UserOwnedPaints = new List<OwnedPaint> { new OwnedPaint { KolboldUserId = 1 } },
                            //    UserPaintRecipes = new List<PaintRecipe> { new PaintRecipe { KolboldUserId = 1 } },
                            //    UserWantedPaints = new List<WantedPaint> { new WantedPaint { KolboldUserId = 1 } },
                            //    UserRefillPaints = new List<RefillPaint> { new RefillPaint { KolboldUserId = 1 } },
                            //    UserTutorials = new List<Tutorial> { new Tutorial { KolboldUserId = 1 } }

            },
            new UserInfoData { Email = "clark@example.com", FirstName = "Zayden", LastName = "Clark" },
            new UserInfoData { Email = "hareem@example.com", FirstName = "Hareem", LastName = "Davila" },
            new UserInfoData { Email = "krzysztof@example.com", FirstName = "Krzysztof", LastName = "Ponce" }
    };
}


//     public List<PersonList> ListKindNames { get; set; } = new List<>
//     {
//         new PersonList
//         {
//             ListKind = "Currently Playing",
//             ListKindId = 1
//         },
//         new PersonList
//         {
//             ListKind = "Completed",
//             ListKindId = 2
//         },
//         new PersonList
//         {
//             ListKind = "Want to Play",
//             ListKindId = 3
//         }
//     };
// }
