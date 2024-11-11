using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Company.e_Tickets.PL.Models
{
    public class ActorViewModel
    {
       public int Id { get; set; } 
        [Required(ErrorMessage = "Image is required.")] 
        public IFormFile Image { get; set; }  

        public string ProfilePictureURL { get; set; } 
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; } 
        [Required(ErrorMessage = "Bio is required.")]
        public string? Bio { get; set; } 

        public ICollection<Actor_Movie> Actor_Movie { get; set; } 
    }
}
