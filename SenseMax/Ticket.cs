using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax
{

    public enum TicketArea { TempHigh, TempLow, HumidityHigh, HumidityLow}
    public class Ticket
    {
        public int TicketId { get; private set; }
        public DateTime TicketDate { get; set; }
        public bool TicketResolved { get; set; }
        public int ArtworkInvolved { get; set; }
        public TicketArea TicketArea { get; set; }

        public Ticket() { }

        public Ticket(DateTime ticketDate, bool ticketResolved, int artworkInvolved, TicketArea ticketArea)
        {
            TicketDate = ticketDate;
            TicketResolved = ticketResolved;
            ArtworkInvolved = artworkInvolved;
            TicketArea = ticketArea;
        }

        public override string ToString()
        {
            return $"Ticket id: {TicketId}, Ticket date: {TicketDate}, Is ticket resolved: {TicketResolved}, Artwork involved: {ArtworkInvolved}";
        }
    }
}
