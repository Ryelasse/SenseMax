using SenseMax;
namespace SenseRepositoryDB;

public interface IProfileRepositoryDB
{
    public IEnumerable<Profile> GetProfile(int? profileId = null, string? profileName = null);
    public Profile AddProfile(Profile profile);
    public Profile? DeleteProfile(int id);
    public Profile? UpdateProfile(int id, Profile data);
}