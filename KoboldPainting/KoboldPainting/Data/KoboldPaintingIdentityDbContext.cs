using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Data
{
    public class KoboldPaintingIdentityDbContext : IdentityDbContext
    {
        public KoboldPaintingIdentityDbContext(DbContextOptions<KoboldPaintingIdentityDbContext> options)
            : base(options)
        {
        }
    }
}