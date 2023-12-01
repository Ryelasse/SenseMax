using SenseMax;
using System.ComponentModel.Design;

namespace SenseRepositoryDB;

public class ArtworkRepositoryDB : IRepositoryDB<Artwork>
{
    private readonly ArtworkDbContext _context;
    private readonly TicketRepositoryDB _ticketRepository;

    public ArtworkRepositoryDB(ArtworkDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        _context = dbContext;
      
    }

    public Artwork? AddEntity(Artwork artwork)
    {
        try
        {
            _context.Artwork.Add(artwork);
            _context.SaveChanges();
            return artwork;
        }
        catch (ArgumentOutOfRangeException aex)
        {
            return null;
        }
    }

    public Artwork? DeleteEntity(int id)
    {
        Artwork? foundArtwork = GetEntityById(id);

        if (foundArtwork != null)
        {
            _context.Artwork.Remove(foundArtwork);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke");
        }
        return foundArtwork;
    }

    public IEnumerable<Artwork> GetEntities()
    {
        IQueryable<Artwork> artworks = _context.Artwork.AsQueryable();

        if (!artworks.Any())
        {
            throw new InvalidOperationException("Listen er tom.");
        }

        return artworks;
    }

    public Artwork? GetEntityById(int id)
    {
        Artwork? artwork = _context.Artwork.FirstOrDefault(a => a.ArtworkId == id);

        if (artwork == null)
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
        }
        return artwork;
    }

    public Artwork? UpdateEntity(int id, Artwork data)
    {
        Artwork? artworkToUpdate = GetEntityById(id);

        if (artworkToUpdate != null)
        {
            artworkToUpdate.ActualTemp = data.ActualTemp;
            artworkToUpdate.ActualHumidity = data.ActualHumidity;
            artworkToUpdate.MinTemp = data.MinTemp;
            artworkToUpdate.MaxTemp = data.MaxTemp;
            artworkToUpdate.MinHumidity = data.MinHumidity;
            artworkToUpdate.MaxHumidity = data.MaxHumidity;

          
            _context.Artwork.Update(artworkToUpdate);
            _context.SaveChanges();

            CreateTemperatureTicket(artworkToUpdate);
            CreateHumidityTicket(artworkToUpdate);

        }
        else
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
        }
        return artworkToUpdate;
    }


    public void CreateTemperatureTicket(Artwork artwork)
    {
        if (artwork.ActualTemp > artwork.MaxTemp)
        {
            _ticketRepository.AddEntity(new Ticket(DateTime.Now, ticketResolved: false, artwork.ArtworkId, TicketArea.TempHigh));
        }
        else if (artwork.ActualTemp < artwork.MinTemp)
        {
                _ticketRepository.AddEntity(new Ticket(DateTime.Now, ticketResolved: false, artwork.ArtworkId, TicketArea.TempLow));
        }
       
    }

    public Ticket CreateHumidityTicket(Artwork artwork)
    {
        if (artwork.ActualHumidity > artwork.MaxHumidity)
        {
            return _ticketRepository.AddEntity(new Ticket(DateTime.Now, ticketResolved: false, artwork.ArtworkId, TicketArea.HumidityHigh));
        }
        else if (artwork.ActualHumidity < artwork.MinHumidity)
        {
            return _ticketRepository.AddEntity(new Ticket(DateTime.Now, ticketResolved: false, artwork.ArtworkId, TicketArea.HumidityLow));
        }
        else
        {
            return null;
        }
    }

}




