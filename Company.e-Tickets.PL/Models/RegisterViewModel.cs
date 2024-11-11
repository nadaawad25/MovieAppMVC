using System.ComponentModel.DataAnnotations;

namespace Company.e_Tickets.PL.Models
    {
        public class RegisterViewModel
        {
          public string FullName { get; set; }
           
            [Required(ErrorMessage = "Username is Required")]
            public string UserName { get; set; } 

            [Required(ErrorMessage = "Email is Required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; } 


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
    }
    }


