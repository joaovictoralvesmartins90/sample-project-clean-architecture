
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId);
    Task<int> CreateDish(Dish dish);
    Task DeleteDishFromRestaurant(int dishId, int restaurantId);
    Task<Dish> GetDishByIdFromRestaurant(int dishId, int restaurantId);
    Task SaveChanges();
}
