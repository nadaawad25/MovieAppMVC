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
    public class GenericRepository <T> : IGenericRepository <T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity) =>
            await _appDbContext.AddAsync(entity);

        public void Delete(T entity) =>
            _appDbContext.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Movie) )
            {
               return (IEnumerable<T>)await _appDbContext.Movies.Include(m => m.Cinema).ToListAsync();
            }

            else
            {
                return (IEnumerable<T>)await _appDbContext.Set<T>().ToListAsync();
            }
        }
         

        public async Task<T> GetByIdAsync(int id) =>
           await _appDbContext.Set<T>().FindAsync(id);
       

        public void Update(T entity) =>
            _appDbContext.Update(entity);
        
    }
}
