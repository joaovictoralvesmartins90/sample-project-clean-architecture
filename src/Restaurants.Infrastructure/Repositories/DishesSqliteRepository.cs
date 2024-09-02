using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class DishesSqliteRepository(RestaurantsSqliteDbContext dbContext) : IDishesRepository
{
    public async Task<int> CreateDish(Dish dish, int restaurantId)
    {
        var restaurant = dbContext.Restaurants.Where(r => r.Id == restaurantId).FirstOrDefault();
        restaurant?.Dishes.Add(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task DeleteDishFromRestaurant(int restaurantId, int dishId)
    {
        var dish = await dbContext.Dishes.Where(d => d.RestaurantId == restaurantId && d.Id == dishId).FirstOrDefaultAsync();
        dbContext.Remove(dish);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Dish> GetDishByIdFromRestaurant(int restaurantId, int dishId)
    {
        var dish = await dbContext.Dishes.Where(d => d.RestaurantId == restaurantId && d.Id == dishId).FirstOrDefaultAsync();
        return dish;
    }

    public async Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId)
    {
        var dishes = await dbContext.Dishes.Where(d => d.RestaurantId == restaurantId).ToListAsync();
        return dishes;
    }
}
