using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Condo> Condos => Set<Condo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condo>()
                .HasIndex(c => new { c.BuildingId, c.CondoNumber})
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
