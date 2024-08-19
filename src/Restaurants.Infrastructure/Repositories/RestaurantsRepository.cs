using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext restaurantsDbContext) : IRestaurantRepository
{
    public async Task<int> Create(Restaurant restaurant)
    {
        restaurantsDbContext.Restaurants.Add(restaurant);
        await restaurantsDbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public void DeleteRestaurant(int id)
    {
        var restaurant = restaurantsDbContext.Restaurants.SingleOrDefault(r => r.Id == id);
        restaurantsDbContext.Remove(restaurant);
        restaurantsDbContext.SaveChanges();
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        var restaurants = await restaurantsDbContext.Restaurants.Include(r => r.Dishes).ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await restaurantsDbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}