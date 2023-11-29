namespace MaliZ.Entities;

public class AppUser
{
    public int Id { get; set; }

    private string UserName;

    public string GetUserName()
    {
        return UserName;
    }

    public void SetUserName(string value)
    {
        UserName = value;
    }

    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public string Username { get; internal set; }
}