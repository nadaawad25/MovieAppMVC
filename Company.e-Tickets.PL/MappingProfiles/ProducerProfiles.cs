using AutoMapper;
using Company.e_Tickets.PL.Models;
using DAL.Models;

namespace Company.e_Tickets.PL.MappingProfiles
{
    public class ProducerProfiles :Profile
    {
        public ProducerProfiles()
        {
            CreateMap<ProducerViewModel, Producer>().ReverseMap();
        }
    }
}
