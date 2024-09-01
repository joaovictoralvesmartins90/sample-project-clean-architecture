using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class DishesSqliteRepository(RestaurantsSqliteDbContext dbContext) : IDishesRepository
{
    public Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId)
    {
        var dishes = dbContext.Dishes.Where()
    }
}
