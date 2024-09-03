using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class DishesRepository(RestaurantsSqliteDbContext dbContext) : IDishesRepository
{
    public async Task<int> CreateDish(Dish dish)
    {
        dbContext.Dishes.Add(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task DeleteDishFromRestaurant(int dishId, int restaurantId)
    {
        var dish = await dbContext.Dishes.Where(d => d.Id == dishId && d.RestaurantId == restaurantId).FirstOrDefaultAsync();
        dbContext.Remove(dish);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Dish> GetDishByIdFromRestaurant(int dishId, int restaurantId)
    {
        var dish = await dbContext.Dishes.Where(d => d.Id == dishId && d.RestaurantId == restaurantId).FirstOrDefaultAsync();
        return dish;
    }

    public async Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId)
    {
        var dishes = await dbContext.Dishes.Where(d => d.RestaurantId == restaurantId).ToListAsync();
        return dishes;
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}
