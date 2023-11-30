namespace SenseRepositoryDB;
using SenseMax;

public class ProfileRepositoryDB : IRepositoryDB<Profile>
{
    private readonly ProfileDBContext _context;

    public ProfileRepositoryDB(ProfileDBContext dbContext)
    {
        dbContext.Database.EnsureCreated();
        _context = dbContext;
    }

    public Profile? AddEntity(Profile profile)
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

    public Profile? DeleteEntity(int id)
    {
        Profile? foundProfile = GetEntityById(id);
        
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

    public IEnumerable<Profile> GetEntities()
    {
        IQueryable<Profile> profiles = _context.Profile.AsQueryable();

        if (!profiles.Any())
        {
            throw new InvalidOperationException("Listen er tom.");
        }

        return profiles;
    }

    public Profile? GetEntityById(int id)
    {
        Profile? profile = _context.Profile.FirstOrDefault(p => p.ProfileId == id);
        
        if (profile == null)
        {
            throw new KeyNotFoundException($"Id: {id} findes ikke i databasen");
        }
        return profile;
    }

    public Profile? UpdateEntity(int id, Profile data)
    {
        Profile? profileToUpdate = GetEntityById(id);

        if (profileToUpdate != null)
        {
            profileToUpdate.ProfileName = data.ProfileName;
            profileToUpdate.Password = data.Password;
            profileToUpdate.ProfilPicture = data.ProfilPicture;

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