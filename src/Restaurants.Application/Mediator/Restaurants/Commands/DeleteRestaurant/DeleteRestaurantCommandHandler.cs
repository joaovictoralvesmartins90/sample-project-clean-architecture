using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository, ILogger<DeleteRestaurantCommandHandler> logger, IMapper mapper) : 
    IRequestHandler<DeleteRestaurantCommand, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id {request.Id}...");
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync( request.Id );
        restaurantRepository.DeleteRestaurant(request.Id);
        return mapper.Map<RestaurantDto>( restaurant );
    }
}
