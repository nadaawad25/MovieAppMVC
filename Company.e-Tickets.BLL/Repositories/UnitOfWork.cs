using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.e_Tickets.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IActorRepository ActorRepository { get; set; }
        public IProducerRepository ProducerRepository { get; set; }
        public ICinemaRepository CinemaRepository { get; set; }
        public IMovieRepository MovieRepository { get; set; }

        public UnitOfWork(AppDbContext context, IActorRepository actorRepository,
                          IProducerRepository producerRepository, ICinemaRepository cinemaRepository,
                          IMovieRepository movieRepository)
        {
            _context = context;
            ActorRepository = actorRepository;
            ProducerRepository = producerRepository;
            CinemaRepository = cinemaRepository;
            MovieRepository = movieRepository;
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                
                throw new Exception("Error saving changes to the database.", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }

}