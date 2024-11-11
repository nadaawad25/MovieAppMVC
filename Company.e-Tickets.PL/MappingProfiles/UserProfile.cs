using AutoMapper;
using Company.e_Tickets.DAL.Models;
using Company.e_Tickets.PL.Models;

namespace Company.e_Tickets.PL.MappingProfiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}
