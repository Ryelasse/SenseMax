using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime TicketDate { get; set; }
        public bool TicketResolved { get; set; }
        public int ResolvedBy { get; set; }
        public int ArtworkInvolved { get; set; }

        public Ticket() { }

        public Ticket(int ticketId, DateTime ticketDate, bool ticketResolved, int resolvedBy, int artworkInvolved)
        {
            TicketId = ticketId;
            TicketDate = ticketDate;
            TicketResolved = ticketResolved;
            ResolvedBy = resolvedBy;
            ArtworkInvolved = artworkInvolved;
        }

        public override string ToString()
        {
            return $"Ticket id: {TicketId}, Ticket date: {TicketDate}, Is ticket resolved: {TicketResolved}, " +
                   $"Resolved by employee: {ResolvedBy}, Artwork involved: {ArtworkInvolved}";
        }
    }
}
