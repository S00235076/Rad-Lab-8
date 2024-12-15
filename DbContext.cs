using Microsoft.EntityFrameworkCore;
using Pets.data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Pets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vet> Pets { get; set; }
        public DbSet<VetVisit> VetVisits { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Pets)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Vet>()
                .HasMany(p => p.VetVisits)
                .WithOne(v => v.Pet)
                .HasForeignKey(v => v.PetId);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.VetVisits)
                .WithOne(v => v.Pet);
        }
    }
}
