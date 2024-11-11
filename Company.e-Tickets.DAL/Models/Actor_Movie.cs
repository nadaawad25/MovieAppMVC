using DAL.Models;

public class Actor_Movie
{
    public int ActorId { get; set; }
    public Actor Actor { get; set; } // Navigation property

    public int MovieId { get; set; }
    public Movie Movie { get; set; } // Navigation property
}
