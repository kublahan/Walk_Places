using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Walk_Places.Models;

namespace Walk_Places.Data
{
    public class WalkPlacesDbContext : IdentityDbContext<IdentityUser>
    {
        public WalkPlacesDbContext(DbContextOptions<WalkPlacesDbContext> options)
        : base(options)
        {
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>()
                .Property(p => p.PhotoPath)
                .IsRequired();

            modelBuilder.Entity<IdentityUserLogin<string>>()
             .ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(x => new { x.LoginProvider, x.ProviderKey });
        }
    }
}
