using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;
internal class RestaurantsServices(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsServices> logger, IMapper mapper) : IRestaurantsServices
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllRestaurantsAsync();
        return mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
    }

    public async Task<RestaurantDto> GetRestaurantById(int id)
    {
        logger.LogInformation($"Getting restaurant with id ${id}");
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync(id);
        return mapper.Map<RestaurantDto>(restaurant);
    }
}