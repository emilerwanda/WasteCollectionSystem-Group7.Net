// Install-Package Microsoft.EntityFrameworkCore
using WasteCollectionSystem.Models;
using Microsoft.EntityFrameworkCore; // This requires the NuGet package.
using System.Collections.Generic;
using System.Reflection.Emit;
using WasteCollectionSystem.Models;

namespace WasteCollectionSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WasteRequest> WasteRequests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User → WasteRequests
            modelBuilder.Entity<User>()
                .HasMany(u => u.WasteRequests)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserID);

            // WasteRequest → Payments
            modelBuilder.Entity<WasteRequest>()
                .HasMany(r => r.Payments)
                .WithOne(p => p.WasteRequest)
                .HasForeignKey(p => p.RequestID);

            // WasteRequest → Assignments
            modelBuilder.Entity<WasteRequest>()
                .HasMany(r => r.Assignments)
                .WithOne(a => a.WasteRequest)
                .HasForeignKey(a => a.RequestID);

            // Truck → Assignments
            modelBuilder.Entity<Truck>()
                .HasMany(t => t.Assignments)
                .WithOne(a => a.Truck)
                .HasForeignKey(a => a.TruckID);
        }
    }
}

