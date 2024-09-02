using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Dishes.Queries.GetDishByIdFromRestaurant;

public class GetDishByIdFromRestaurantHandler(IDishesRepository dishesRepository,
        IRestaurantsRepository restaurantsRepository,
        ILogger<GetDishByIdFromRestaurantHandler> logger, IMapper mapper) : IRequestHandler<GetDishByIdFromRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdFromRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting dishes {request.DishId} from restaurant {request.RestaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.RestaurantId);

        if (restaurant == null)
        {
            throw new NotFoundException($"Restaurant with id {request.RestaurantId} not found.");
        }

        var dish = await dishesRepository.GetDishByIdFromRestaurant(request.RestaurantId, request.DishId);

        if (dish == null)
        {
            throw new NotFoundException($"Dish with id {request.DishId} not found.");
        }

        return mapper.Map<DishDto>(dish);
    }
}
