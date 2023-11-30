using Microsoft.EntityFrameworkCore;
using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class DutyDBContext : DbContext
    {
        public DutyDBContext(DbContextOptions<DutyDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duty>()
                .Property(d => d.DutyId)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Duty> Duty { get; set; }
    }
}