using DAL.Models;

namespace Company.e_Tickets.PL.Models
{
    public class CinemaViewModel
    {
        public int Id { get; set; } 

        public string Logo { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 

        public ICollection<Movie> Movies { get; set; } 
    }
}
