
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId);
    Task<int> CreateDish(Dish dish, int restaurantId);
    Task DeleteDishFromRestaurant(int restaurantId, int dishId);
    Task<Dish> GetDishByIdFromRestaurant(int restaurantId, int dishId);
}
