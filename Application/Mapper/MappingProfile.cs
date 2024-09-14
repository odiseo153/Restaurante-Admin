using Application.Entities.PLatos.Command;
using Application.Entities.Restaurantes.Command;
using AutoMapper;
using Core.Entities;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<CreateRestaurantCommand, Restaurants>().ReverseMap();
          CreateMap<CreatePlatoCommand, Plato>().ReverseMap();


        }
    }
}



