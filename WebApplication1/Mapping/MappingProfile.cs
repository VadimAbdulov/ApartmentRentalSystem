using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.DTOs.WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Apartment, ApartmentDto>();

            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<RentCreateDto, Rent>();
        }
    }
}
