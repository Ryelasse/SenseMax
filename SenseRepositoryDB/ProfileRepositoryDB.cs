namespace SenseRepositoryDB;
using SenseMax

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

    }
}