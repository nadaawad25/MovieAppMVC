using Company.e_Tickets.BLL.Interfaces;
using Company.e_Tickets.PL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.e_Tickets.PL.Controllers
{
    public class MovieController :Controller
    {
        private IUnitOfWork _unitOfWork;
        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            IEnumerable<Movie> movies;
            if(string.IsNullOrEmpty(SearchValue))
            
                movies = await _unitOfWork.MovieRepository.GetAllAsync();
            
            else
                movies=  _unitOfWork.MovieRepository.GetByNameAsync(SearchValue);
            
            var MappedMovies = movies.Select(Movie => new MovieViewModel
            {
                ImageUrl = Movie.ImageUrl,
                Background = Movie.Background,
                Name = Movie.Name,
                Description = Movie.Description,
                Price = Movie.Price,
                StartDate = Movie.StartDate,
                EndDate = Movie.EndDate,
                CinemaId = Movie.CinemaId, // Map CinemaId
                Cinema = Movie.Cinema,

            }).ToList();
            return View(MappedMovies);
        }

    }
}
