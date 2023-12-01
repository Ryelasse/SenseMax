using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class TicketRepositoryDB : IRepositoryDB<Ticket>
    {
        private readonly TicketDbContext _context;

        public TicketRepositoryDB(TicketDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }

        public Ticket? AddEntity(Ticket ticket)
        {
            try
            {
                _context.Ticket.Add(ticket);
                _context.SaveChanges();
                return ticket;
            }
            catch (ArgumentOutOfRangeException aex)
            {
                return null;
            }
        }

        public Ticket? DeleteEntity(int id)
        {
            Ticket? foundTicket = GetEntityById(id);

            if (foundTicket != null)
            {
                _context.Ticket.Remove(foundTicket);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke");
            }
            return foundTicket;
        }

        public IEnumerable<Ticket> GetEntities()
        {
            IQueryable<Ticket> ticket = _context.Ticket.AsQueryable();

            if (!ticket.Any())
            {
                throw new InvalidOperationException("Listen er tom.");
            }

            return ticket;
        }

        public Ticket? GetEntityById(int id)
        {
            Ticket? ticket = _context.Ticket.FirstOrDefault(t => t.TicketId == id);

            if (ticket == null)
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return ticket;
        }

        public Ticket? UpdateEntity(int id, Ticket data)
        {
            Ticket? ticketToUpdate = GetEntityById(id);

            if (ticketToUpdate != null)
            {
                ticketToUpdate.TicketResolved = data.TicketResolved;
                ticketToUpdate.ArtworkInvolved = data.ArtworkInvolved;
                ticketToUpdate.TicketArea = data.TicketArea;


                _context.Ticket.Update(ticketToUpdate);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return ticketToUpdate;



        }
    }
}
