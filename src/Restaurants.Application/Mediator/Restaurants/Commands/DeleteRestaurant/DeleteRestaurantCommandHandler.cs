using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository, ILogger<DeleteRestaurantCommandHandler> logger) : 
    IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id {request.Id}...");
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync( request.Id );

        if(restaurant is not null)
        {
            restaurantRepository.DeleteRestaurant(request.Id);
            return true;
        }
        return false;
    }
}
