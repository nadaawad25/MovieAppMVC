using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string  ProfilePictureURL{ get; set; }
        public string FullName { get; set; }
        public string? Bio { get; set; }
       
        public ICollection<Movie> Movies { get; set; }

     


    }
}
