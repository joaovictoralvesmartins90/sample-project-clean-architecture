using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Dishes.Commands.UpdateDish;

public class UpdateDishCommandHandler(ILogger<UpdateDishCommandHandler> logger,
    IDishesRepository dishesRepository,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateDishCommand>
{
    public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating dish with id {request.DishId}...");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

        if (restaurant is null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }

        var dish = await dishesRepository.GetDishByIdFromRestaurant(request.DishId, request.RestaurantId);

        if (restaurant is null)
        {
            throw new NotFoundException($"Dish with id {request.DishId} not found.");
        }

        dish.Name = request.Name;
        dish.Description = request.Description;
        dish.KiloCalories = request.KiloCalories;
        dish.Price = request.Price;

        await dishesRepository.SaveChanges();
    }
}