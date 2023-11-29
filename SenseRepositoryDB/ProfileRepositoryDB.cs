namespace SenseRepositoryDB;
using SenseMax;

public class ProfileRepositoryDB : IProfileRepositoryDB
{
    private readonly ProfileDBContext _context;

    public ProfileRepositoryDB(ProfileDBContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        _context = dbContext;
    }

    public Profile? AddProfile(Profile profile)
    {
        try
        {
            _context.Profile.Add(profile);
            _context.SaveChanges();
            return profile;
        }
        catch (ArgumentOutOfRangeException aex)
        {
            return null;
        }
        catch (ArgumentException aoorex)
        {
            return null;
        }
    }

    public Profile? DeleteProfile(int id)
    {
        Profile? foundProfile = GetProfileById(id);
        
        if (foundProfile != null)
        {
            _context.Profile.Remove(foundProfile);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke");
        }
        return foundProfile;
    }

    public IEnumerable<Profile> GetProfiles(int? idAfter = null, string? nameIncludes = null, string? orderBy = null)
    {
        IQueryable<Profile> filter = _context.Profile.AsQueryable();

        if (nameIncludes != null)
        {
            filter = filter.Where(p => p.ProfileId > idAfter);
        }

        if (nameIncludes != null)
        {
            filter = filter.Where(p => p.ProfileName.Contains(nameIncludes));
        }

        if (orderBy != null)
        {
            orderBy = orderBy.ToLower();
            switch (orderBy)
            {
                case "name":
                case "name_asc":
                    filter = filter.OrderBy(p => p.ProfileName);
                    break;
                default:
                    throw new ArgumentException("Ukendt filter: " + orderBy);
            }
        }

        if (!filter.Any())
        {
            throw new InvalidOperationException("Listen er tom.");
        }

        return filter;
    }

    public Profile? GetProfileById(int id)
    {
        Profile? profile = _context.Profile.FirstOrDefault(p => p.ProfileId == id);
        
        if (profile == null)
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
        }
        return profile;
    }

    public Profile? UpdateProfile(int id, Profile data)
    {
        Profile? profileToUpdate = GetProfileById(id);

        if (profileToUpdate != null)
        {
            profileToUpdate.ProfileName = data.ProfileName;
            profileToUpdate.Password = data.Password;

            _context.Profile.Update(profileToUpdate);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
        }
        return profileToUpdate;
    }
}