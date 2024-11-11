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
    public class CinemaRepository :  GenericRepository<Cinema>, ICinemaRepository
    {
        private AppDbContext _appDbContext;
        public CinemaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
