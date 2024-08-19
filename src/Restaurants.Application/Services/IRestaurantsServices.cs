using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Services;

public interface IRestaurantsServices
{
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto> GetRestaurantById(int id);
    Task<int> Create(CreateRestaurantDto createRestaurantDto);
    void DeleteRestaurant(int id);
}