using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Company.e_Tickets.PL.Models
{
    public class ProducerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile Image { get; set; }
        public string ProfilePictureURL { get; set; } 
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is required.")]
        public string? Bio { get; set; }
        public ICollection<Movie> Movies { get; set; } 

    }
}
