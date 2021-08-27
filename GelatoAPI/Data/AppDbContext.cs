using GelatoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GelatoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Users
            modelBuilder.Entity<AppUser>()
                .HasData(
                    new AppUser { Id = 1, UserName = "Lucas", IsAdmin = true },
                    new AppUser { Id = 2, UserName = "Cid", IsAdmin = true },
                    new AppUser { Id = 3, UserName = "Suélen", IsAdmin = true }
                );
        }
    }
}
