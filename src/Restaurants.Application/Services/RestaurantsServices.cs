using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Services;
internal class RestaurantsServices(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsServices> logger, IMapper mapper) : IRestaurantsServices
{
    public async Task<int> Create(CreateRestaurantDto createRestaurantDto)
    {
        logger.LogInformation("Creating new restaurant");
        Restaurant restaurant = mapper.Map<Restaurant>(createRestaurantDto);
        return await restaurantRepository.Create(restaurant);
    }

    public void DeleteRestaurant(int id)
    {
        logger.LogInformation($"Deleting restaurant with id {id}...");
        restaurantRepository.DeleteRestaurant(id);
    }

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