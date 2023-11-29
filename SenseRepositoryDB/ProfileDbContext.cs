using Microsoft.EntityFrameworkCore;
using SenseMax;

namespace SenseRepositoryDB
{
    public class ProfileDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }
        public ProfileDBContext(DbContextOptions<ProfileDBContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
    }
}