using Microsoft.Identity.Client;
using SenseMax;
namespace SenseRepositoryDB;

public interface IProfileRepositoryDB
{
    public IEnumerable<Profile> GetProfiles(int? idAfter = null, string? nameIncludes = null, string? orderBy = null);
    public Profile? GetProfileById(int id);
    public Profile? AddProfile(Profile profile);
    public Profile? DeleteProfile(int id);
    public Profile? UpdateProfile(int id, Profile data);
}