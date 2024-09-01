using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Mediator.Dishes.Queries.GetAllDishesFromRestaurant;

public class GetAllDishesFromRestaurantQuery: IRequest<IEnumerable<DishDto>>
{
    public GetAllDishesFromRestaurantQuery(int restaurantId)
    {
        RestaurantId = restaurantId;
    }
    public int RestaurantId { get; init; }
}
