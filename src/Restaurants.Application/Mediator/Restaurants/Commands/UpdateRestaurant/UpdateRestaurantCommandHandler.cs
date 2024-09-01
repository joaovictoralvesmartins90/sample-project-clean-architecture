using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IDishesRepository restaurantRepository) : IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating restaurant with id {request.Id}...");
        logger.LogInformation("Updating restaurant: {@Restaurant}", request);
        var restaurantDB = await restaurantRepository.GetRestaurantByIdAsync(request.Id);
        
        if (restaurantDB is null)
        {
            throw new NotFoundException($"Restaurant with id {request.Id} not found.");
        }

        restaurantDB.Name = request.Name;
        restaurantDB.Description = request.Description;
        restaurantDB.HasDelivery = request.HasDelivery;

        await restaurantRepository.SaveChanges();
    }
}
