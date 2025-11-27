using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WasteCollectionSystem.Models;

namespace WasteCollectionSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WasteRequest> WasteRequests { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Truck> Trucks { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // WasteRequest → User (string key)
            modelBuilder.Entity<WasteRequest>()
                .HasOne(r => r.User)
                .WithMany(u => u.WasteRequests)
                .HasForeignKey(r => r.UserId);

            // Other relationships stay the same
            modelBuilder.Entity<WasteRequest>()
                .HasMany(r => r.Payments)
                .WithOne(p => p.WasteRequest)
                .HasForeignKey(p => p.RequestID);

            modelBuilder.Entity<WasteRequest>()
                .HasMany(r => r.Assignments)
                .WithOne(a => a.WasteRequest)
                .HasForeignKey(a => a.RequestID);

            modelBuilder.Entity<Truck>()
                .HasMany(t => t.Assignments)
                .WithOne(a => a.Truck)
                .HasForeignKey(a => a.TruckID);
        }
    }
}