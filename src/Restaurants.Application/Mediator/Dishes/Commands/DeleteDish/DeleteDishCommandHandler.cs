using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Dishes.Commands.DeleteDish;

public class DeleteDishCommandHandler(ILogger<DeleteDishCommandHandler> logger, IDishesRepository dishesRepository, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting dish {request.DishId} from restaurant {request.RestaurantId}...");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

        if (restaurant == null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }

        var dish = await dishesRepository.GetDishByIdFromRestaurant(request.DishId, request.RestaurantId);

        if (dish == null)
        {
            throw new NotFoundException($"Dish with id {request.DishId} not found.");
        }

        await dishesRepository.DeleteDishFromRestaurant(request.DishId, request.RestaurantId);

    }
}
