using Company.e_Tickets.DAL.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Background { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 

        public MovieCategory MovieCategory { get; set; }

        [ForeignKey(nameof(Producer))]
        public  int ProducerId {  get; set; }
        public Producer Producer { get; set; }

        public ICollection<Actor_Movie> Actor_Movies { get; set; }

        [ForeignKey(nameof(Cinema))]
        public int CinemaId {  get; set; }
        public Cinema Cinema { get; set; }







    }
}
