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

    public Profile AddProfile(Profile profile)
    {
        try
        {
        _context.Profiles.Add(profile);
        _context.SaveChanges();
        return profile;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Profile? DeleteProfile(int id)
    {
        Profile foundProfile = GetProfileById(id);
        if (foundProfile != null)
        {
            _context.Profiles.Remove(foundProfile);
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
        IQueryable<Profile> filter = _context.Profiles.AsQueryable();

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
                    throw new ArgumentException("Unknown filter: " + orderBy);
            }
        }
        return filter;
    }

    public Profile? GetProfileById(int id)
    {
        Profile? profile = _context.Profiles.FirstOrDefault(p => p.ProfileId == id);
        if (profile == null)
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke");
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

            _context.Profiles.Update(profileToUpdate);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke");
        }
        return profileToUpdate;
    }
}