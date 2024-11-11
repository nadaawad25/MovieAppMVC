using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }

        public ICollection<Movie> Movies { get; set; } 

     

    }
}
