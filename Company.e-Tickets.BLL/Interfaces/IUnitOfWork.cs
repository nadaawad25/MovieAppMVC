using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.e_Tickets.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IActorRepository ActorRepository { get; set; }
        IProducerRepository ProducerRepository { get; set; }
        ICinemaRepository CinemaRepository { get; set; }
        IMovieRepository MovieRepository { get; set; }
        Task<int> CompleteAsync();
    }
}
