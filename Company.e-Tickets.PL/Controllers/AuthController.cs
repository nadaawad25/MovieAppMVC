using Company.e_Tickets.DAL.Models;
using Company.e_Tickets.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Company.e_Tickets.PL.Controllers
{
    public class AuthController :Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signManager;
        public AuthController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser()
            {
                FullName = model.Email,
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction("Index", "Movie");
            else
                foreach (var item in result.Errors)
                    ModelState.AddModelError(string.Empty, item.Description); 
            
            return View(model);
        }
        //Login 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
                if (isPasswordValid)
                {
                    var result = await _signManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Your account has been locked out. Please try again later.");
                        return View(model);
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "You are not allowed to sign in at this moment.");
                        return View(model);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email does not exist.");
                return View(model);
            }
        }



        //SignOut

        //ForgetPassword

        //ResetPassword
    }
}
