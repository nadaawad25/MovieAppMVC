using AutoMapper;
using Company.e_Tickets.PL.Models;
using DAL.Models;

namespace Company.e_Tickets.PL.MappingProfiles
{
    public class ActorProfile :Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorViewModel, Actor>().ReverseMap();
        }
    }
}
