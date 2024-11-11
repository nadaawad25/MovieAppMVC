using AutoMapper;
using Company.e_Tickets.DAL.Models;
using Company.e_Tickets.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.e_Tickets.PL.Controllers
{
    public class UserController :Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<ApplicationUser> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (!string.IsNullOrEmpty(SearchValue))
            {
                var user = await _userManager.FindByNameAsync(SearchValue);

                if (user != null) // Check if user is found
                {
                    var MappedUser = new UserViewModel()
                    {
                        FullName = user.FullName,
                        Bio = user.Bio ?? string.Empty, // Use null-coalescing to set an empty string if Bio is null
                        Email = user.Email,
                        Id = user.Id,
                        Roles = await _userManager.GetRolesAsync(user),
                    };
                    return View(new List<UserViewModel> { MappedUser });
                }
                else
                {
                    // Optionally, return an empty list or a message indicating the user wasn't found
                    return View(new List<UserViewModel>());
                }
            }
            else
            {
                var users = await _userManager.Users.Select(S => new UserViewModel()
                {
                    FullName = S.FullName,
                    Bio = S.Bio ?? string.Empty,
                    Email = S.Email,
                    Id = S.Id,
                    Roles = _userManager.GetRolesAsync(S).Result,
                }).ToListAsync();

                return View(users);
            }
        }



        public async Task<IActionResult> Details(string id ,string ViewName = "Details")
        {
            if (id is null)
               return BadRequest();
            
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            var MappedUser = _mapper.Map<ApplicationUser, UserViewModel>(user);
            
            return View(MappedUser);
        }

    }
}
