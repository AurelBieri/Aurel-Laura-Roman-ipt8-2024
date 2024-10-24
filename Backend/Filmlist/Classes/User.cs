namespace Filmlist.Classes
{

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<MovieList> MovieLists { get; set; } = new List<MovieList>();
}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

}

