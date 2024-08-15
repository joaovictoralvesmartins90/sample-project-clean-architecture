using AutoMapper;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address!.City))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address!.Street))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address!.PostalCode))
            .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));
        CreateMap<RestaurantDto, Restaurant>();
        CreateMap<Dish, DishDto>();
        CreateMap<DishDto, Dish>();
    }
}