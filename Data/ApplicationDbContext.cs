using Microsoft.EntityFrameworkCore;

namespace Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cocktail> Cocktails { get; set; }
    }
}
