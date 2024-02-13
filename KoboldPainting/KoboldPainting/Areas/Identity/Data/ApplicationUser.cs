using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;

namespace KoboldPainting.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    [PersonalData]
    public string FirstName { get; set; }
    [PersonalData]
    public string LastName { get; set; }
}