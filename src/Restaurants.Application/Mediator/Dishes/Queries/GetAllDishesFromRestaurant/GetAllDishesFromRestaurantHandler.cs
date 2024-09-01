using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Dishes.Queries.GetAllDishesFromRestaurant;

public class GetAllDishesFromRestaurantHandler(IDishesRepository dishesRepository,
        ILogger<GetAllDishesFromRestaurantHandler> logger, IMapper mapper) : 
    IRequestHandler<GetAllDishesFromRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesFromRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all dishes from restaurant {request.RestaurantId}");
        var dishes = dishesRepository.GetRestaurantDishes(request.RestaurantId);
        return mapper.Map<IEnumerable<DishDto>>(dishes);
    }
}
