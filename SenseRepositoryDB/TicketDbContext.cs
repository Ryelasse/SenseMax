using Microsoft.EntityFrameworkCore;
using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class TicketDbContext : DbContext
    {
    public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(Secret.GetConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .Property(t => t.TicketId)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Ticket> Ticket { get; set; }

}
}
