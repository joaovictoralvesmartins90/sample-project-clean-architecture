using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Dishes.Queries.GetAllDishesFromRestaurant;

public class GetAllDishesFromRestaurantHandler(IDishesRepository dishesRepository,
        IRestaurantsRepository restaurantsRepository, 
        ILogger<GetAllDishesFromRestaurantHandler> logger, IMapper mapper) : 
    IRequestHandler<GetAllDishesFromRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesFromRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all dishes from restaurant {request.RestaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

        if (restaurant == null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }

        var dishes = await dishesRepository.GetRestaurantDishes(request.RestaurantId);
        return mapper.Map<IEnumerable<DishDto>>(dishes);
    }
}
