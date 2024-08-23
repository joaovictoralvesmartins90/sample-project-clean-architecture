using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsSqliteRepository(RestaurantsSqliteDbContext restaurantsDbContext) : IRestaurantRepository
{
    public async Task<int> Create(Restaurant restaurant)
    {
        restaurantsDbContext.Restaurants.Add(restaurant);
        await restaurantsDbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteRestaurant(int id)
    {
        var restaurant = restaurantsDbContext.Restaurants.SingleOrDefault(r => r.Id == id);
        restaurantsDbContext.Remove(restaurant);
        await restaurantsDbContext.SaveChangesAsync();
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

    public async Task UpdateRestaurant(Restaurant restaurant)
    {
        var restaurantDB = await restaurantsDbContext.Restaurants.FirstAsync(r => r.Id == restaurant.Id);
        restaurantDB.Name = restaurant.Name;
        restaurantDB.Address!.PostalCode = restaurant.Address!.PostalCode;
        restaurantDB.Address!.Street = restaurant.Address!.Street;
        restaurantDB.Address!.City = restaurant.Address!.City;
        restaurantDB.Category = restaurant.Category;
        restaurantDB.ContactEmail = restaurant.ContactEmail;
        restaurantDB.ContactNumber = restaurant.ContactNumber;
        restaurantDB.HasDelivery = restaurant.HasDelivery;
        restaurantDB.Description = restaurant.Description;
        await restaurantsDbContext.SaveChangesAsync();
    }
}