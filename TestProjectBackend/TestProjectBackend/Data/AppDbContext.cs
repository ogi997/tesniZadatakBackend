using Microsoft.EntityFrameworkCore;
using TestProjectBackend.Models.Entities;

namespace TestProjectBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Faktura> Fakture { get; set; }
        public DbSet<StavkaFakture> StavkaFakture { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Korisnik>()
                .HasIndex(p => p.Email)
                .IsUnique();

           
        }
    }
}