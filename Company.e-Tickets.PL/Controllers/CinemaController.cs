using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.PL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.e_Tickets.PL.Controllers
{
    public class CinemaController :Controller
    {
        private IUnitOfWork _unitOfWork;
        public CinemaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var Cinema =await _unitOfWork.CinemaRepository.GetAllAsync();
            var MappedCinema = Cinema.Select(Cinema => new CinemaViewModel
            {
                Logo = Cinema.Logo,
                Name = Cinema.Name,
                Description = Cinema.Description
            }).ToList();
            return View(MappedCinema);
        }
    }
}
