using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.DAL.Data.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.e_Tickets.BLL.Repositories
{
    public class MovieRepository : GenericRepository<Movie> , IMovieRepository
    {
        private readonly AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext) : base(appDbContext) {
            _appDbContext = appDbContext;
        }
  
        public IQueryable<Movie> GetByNameAsync(string SearchValue)
        {
            return _appDbContext.Movies.Include(m =>m.Cinema).Where(m => m.Name.ToLower().Contains(SearchValue.ToLower()));
        }

    }
}
