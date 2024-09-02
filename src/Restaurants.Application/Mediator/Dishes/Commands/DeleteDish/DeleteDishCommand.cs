using MediatR;

namespace Restaurants.Application.Mediator.Dishes.Commands.DeleteDish;

public class DeleteDishCommand: IRequest
{
    public DeleteDishCommand(int restaurantId, int dishId)
    {
        RestaurantId = restaurantId;
        DishId = dishId;
    }

    public int RestaurantId { get; init; }
    public int DishId { get; init; }
}
