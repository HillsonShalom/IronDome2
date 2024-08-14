using IronDome2.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDome2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Launch> Launches { get; set; }
        public DbSet<Threat> Threats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Launch>()
                .HasMany(l => l.Threats)
                .WithOne(t => t.Launch)
                .HasForeignKey(t => t.LaunchId);
        }
    }
}












