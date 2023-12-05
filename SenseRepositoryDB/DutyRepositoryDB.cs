using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseRepositoryDB
{
    public class DutyRepositoryDB : IRepositoryDB<Duty>
    {
        private readonly DutyDBContext _context;

        public DutyRepositoryDB(DutyDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }
        public Duty? AddEntity(Duty duty)
        {
            try
            {
                _context.Duty.Add(duty);
                _context.SaveChanges();
                return duty;
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

        public Duty? DeleteEntity(int id)
        {
            Duty? foundDuty = GetEntityById(id);

            if (foundDuty != null)
            {
                _context.Duty.Remove(foundDuty);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke");
            }
            return foundDuty;
        }

        public IEnumerable<Duty> GetEntities()
        {
            IQueryable<Duty> duties = _context.Duty.AsQueryable();

            if (!duties.Any())
            {
                throw new InvalidOperationException("Listen er tom.");
            }

            return duties;
        }

        public Duty? GetEntityById(int id)
        {
            Duty? duty = _context.Duty.FirstOrDefault(d => d.DutyId == id);

            if (duty == null)
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return duty;
        }

        public Duty? UpdateEntity(int id, Duty data)
        {
            Duty? dutyToUpdate = GetEntityById(id);

            if (dutyToUpdate != null)
            {
                dutyToUpdate.DutyId = data.DutyId;
                dutyToUpdate.DutyStart = data.DutyStart;
                dutyToUpdate.DutyEnd = data.DutyEnd;
             

                _context.Duty.Update(dutyToUpdate);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
            }
            return dutyToUpdate;
        }

    }
}
