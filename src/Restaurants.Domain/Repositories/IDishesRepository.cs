﻿
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<IEnumerable<Dish>> GetRestaurantDishes(int restaurantId);
}
