using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Mediator.Dishes.Queries.GetDishByIdFromRestaurant;

public class GetDishByIdFromRestaurantQuery: IRequest<DishDto>
{
    public GetDishByIdFromRestaurantQuery(int restaurantId, int dishId)
    {
        RestaurantId = restaurantId;
        DishId = dishId;
    }
    public int RestaurantId { get; }
    public int DishId { get; }
}
