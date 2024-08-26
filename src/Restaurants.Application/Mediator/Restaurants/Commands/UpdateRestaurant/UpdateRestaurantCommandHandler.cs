using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating restaurant with id {request.Id}...");
        var restaurantDB = await restaurantRepository.GetRestaurantByIdAsync(request.Id);
        if (restaurantDB == null)
        {
            return false;
        }

        restaurantDB.Name = request.Name;
        restaurantDB.Description = request.Description;
        restaurantDB.HasDelivery = request.HasDelivery;

        await restaurantRepository.SaveChanges();
        return true;
    }
}
