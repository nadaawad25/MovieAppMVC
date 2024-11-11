using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.DAL.Data.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.e_Tickets.BLL.Repositories
{
    public class ActorRepository : GenericRepository<Actor> , IActorRepository
    {
        private readonly AppDbContext _appDbContext;
        public ActorRepository(AppDbContext appDbContext)  : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

     
        
    }
}
