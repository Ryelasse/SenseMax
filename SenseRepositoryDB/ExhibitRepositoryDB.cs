using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class ExhibitRepositoryDB : IRepositoryDB<Exhibit>
    {
        private readonly ExhibitDBContext _context;

        public ExhibitRepositoryDB(ExhibitDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }
        public Exhibit? AddEntity(Exhibit exhibit)
        {
            try
            {
                _context.Exhibit.Add(exhibit);
                _context.SaveChanges();
                return exhibit;
            }
            catch (ArgumentNullException anex)
            {
                return null;
            }
            catch (ArgumentException aex)
            {
                return null;
            }
            
        }

        public Exhibit? DeleteEntity(int id)
        {
            Exhibit? foundExhibit = GetEntityById(id);

            if (foundExhibit != null)
            {
                _context.Exhibit.Remove(foundExhibit);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke");
            }
            return foundExhibit;
        }

        public IEnumerable<Exhibit> GetEntities()
        {
            IQueryable<Exhibit> exhibits = _context.Exhibit.AsQueryable();

            if (!exhibits.Any())
            {
                throw new InvalidOperationException("Listen er tom.");
            }

            return exhibits;
        }

        public Exhibit? GetEntityById(int id)
        {
            Exhibit? exhibit = _context.Exhibit.FirstOrDefault(e => e.ExhibitId == id);

            if (exhibit == null)
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return exhibit;
        }

        public Exhibit? UpdateEntity(int id, Exhibit data)
        {
            Exhibit? exhibitToUpdate = GetEntityById(id);

            if (exhibitToUpdate != null)
            {
                exhibitToUpdate.Name = data.Name;
                exhibitToUpdate.MaxVcount = data.MaxVcount;
                exhibitToUpdate.ActualVcount = data.ActualVcount;

                _context.Exhibit.Update(exhibitToUpdate);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return exhibitToUpdate;
        }





    }
}
