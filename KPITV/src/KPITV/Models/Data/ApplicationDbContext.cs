using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KPITV.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Stuff> Stuff { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .HasIndex(b => b.ProfileLink)
                .IsUnique();
        }
    }
}
