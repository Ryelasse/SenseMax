using Microsoft.EntityFrameworkCore;
using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenseMax;

namespace SenseRepositoryDB
{
    public class ExhibitDBContext : DbContext
    {

        public ExhibitDBContext(DbContextOptions<ExhibitDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exhibit>()
                .Property(p => p.ExhibitId)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Exhibit> Exhibit { get; set; }

    }
   
}
