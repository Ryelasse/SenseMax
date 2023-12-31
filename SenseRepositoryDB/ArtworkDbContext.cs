using Microsoft.EntityFrameworkCore;
using SenseMax;

namespace SenseRepositoryDB 
{
    public class ArtworkDbContext : DbContext
    {
        public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>()
                .HasKey(a => a.ArtworkId);

            modelBuilder.Entity<Artwork>()
                .Property(a => a.ArtworkId)
                .ValueGeneratedOnAdd();
        }


        public DbSet<Artwork> Artwork { get; set; }
    }
}