using System.Text.RegularExpressions;

namespace SenseMax;

public enum Type {
    Curator,
    Security
}

public class Profile
{
    #region Instance Field
    
    private string _profileName;
    private string _password;
    
    #endregion
    
    #region Constructor

    public Profile() {}

    public Profile(string profileName, string password, Type profileType, string profilePicture)
    {
        ProfileName = profileName;
        Password = password;
        ProfileType = profileType;
        ProfilePicture = profilePicture;
    }
    #endregion

    #region Properties

    public int ProfileId { get; private set; }

    public string ProfileName
    {
        get => _profileName;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length >= 2) //checks whether the value is not null and not an empty string. Also checks if the string is greater than or equal to 2 characters
            {
                _profileName = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The name: {_profileName} must be at least two characters.");
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (Regex.IsMatch(value, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"))
            {
                _password = value;
            }
            else
            {
                throw new ArgumentException("Password must contain at least one digit, one lowercase letter, one uppercase letter, and be at least 8 characters long.");
            }
        }
    }
    public Type ProfileType { get; set; }
    
    public string ProfilePicture { get; set; }
    
    #endregion
    
    #region Methods

    public override string ToString()
    {
        return $"ProfileId: {ProfileId}, Name: {ProfileName}, Password: {Password}, Profile: {ProfileType.ToString()}";
    }
    
    #endregion
}