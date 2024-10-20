namespace Filmlist.Classes{
    public class MovieList
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User ?User { get; set; } 

    public string Name { get; set; }

    public ICollection<MovieItem> ?Movies { get; set; } = new List<MovieItem>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

}