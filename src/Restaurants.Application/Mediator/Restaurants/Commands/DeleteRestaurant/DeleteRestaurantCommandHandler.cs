using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IDishesRepository restaurantRepository, ILogger<DeleteRestaurantCommandHandler> logger) : 
    IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id {request.Id}...");
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync( request.Id );

        if(restaurant is null)
        {
            throw new NotFoundException($"Restaurant with id {request.Id} not found.");
        }
        await restaurantRepository.DeleteRestaurant( request.Id );
    }
}
