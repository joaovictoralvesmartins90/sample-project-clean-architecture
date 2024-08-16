using Restaurants.Application.Dtos;

namespace Restaurants.Application.Services;

public interface IRestaurantsServices
{
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto> GetRestaurantById(int id);
    Task<int> Create(CreateRestaurantDto createRestaurantDto);
}