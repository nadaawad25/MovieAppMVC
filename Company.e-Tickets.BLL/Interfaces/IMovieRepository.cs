using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.e_Tickets.BLL.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IQueryable<Movie> GetByNameAsync(string SearchValue);
    }
}
