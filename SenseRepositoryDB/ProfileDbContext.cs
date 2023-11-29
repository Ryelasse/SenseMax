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
        public DbSet<Profile> Profiles { get; set; }
    }
}