namespace Filmlist.Classes{
    public class MovieItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsWatched { get; set; } = false;

    public int MovieListId { get; set; }
    public MovieList MovieList { get; set; }
}
}