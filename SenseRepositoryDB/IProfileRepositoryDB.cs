using SenseMax;
namespace SenseRepositoryDB;

public interface IProfileRepositoryDB
{
    public IEnumerable<Profile> GetProfile(int? idAfter = null, string? nameIncludes = null, string? orderBy = null);
    public Profile AddProfile(Profile profile);
    public Profile? DeleteProfile(int id);
    public Profile? UpdateProfile(int id, Profile data);
}