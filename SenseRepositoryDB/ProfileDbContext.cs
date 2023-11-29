using Microsoft.EntityFrameworkCore;
using SenseMax;

namespace SenseRepositoryDB
{
    public class ProfileDBContext : DbContext
    {
        public ProfileDBContext(DbContextOptions<ProfileDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(p => p.ProfileId)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Profile> Profile { get; set; }
    }
}