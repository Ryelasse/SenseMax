namespace SenseRepositoryDB;
using SenseMax;

public class ProfileRepositoryDB : IProfileRepositoryDB
{
    private readonly ProfileDbContext _context;

    public ProfileRepositoryDB(ProfileDbContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        _context = dbContext;
    }

    public Profile AddProfile(Profile profile)
    {
        _context.Profiles.Add(profile);
        _context.SaveChanges();
        return profile;
    }

    public Profile? DeleteProfile(int id)
    {
        Profile foundProfile = _context.Profiles.ToList<Profile>().Find(x => x.ProfileId == id);
        if (foundProfile != null)
        {
            _context.Profiles.Remove(foundProfile);
            _context.SaveChanges();
        }

        return foundProfile;
    }

    public IEnumerable<Profile> GetProfile(int? idAfter = null, string? nameIncludes = null, string? orderBy = null)
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

    public Profile? UpdateProfile(int id, Profile data)
    {
        Profile? profileToUpdate = _context.Profiles.FirstOrDefault(p => p.ProfileId == id);

        if (profileToUpdate != null)
        {
            profileToUpdate.ProfileName = data.ProfileName;
            profileToUpdate.Password = data.Password;

            _context.Profiles.Update(profileToUpdate);
            _context.SaveChanges();
        }
        return profileToUpdate;
    }
}