using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KoboldPainting.Areas.Identity.Data;

namespace KoboldPainting.Data
{
    public class KoboldPaintingIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public KoboldPaintingIdentityDbContext(DbContextOptions<KoboldPaintingIdentityDbContext> options)
            : base(options)
        {
        }
    }
    
    // {
    //     public KoboldPaintingIdentityDbContext(DbContextOptions<KoboldPaintingIdentityDbContext> options)
    //         : base(options)
    //     {
    //     }
    // }
}