using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Mediator.Restaurants.Queries.GetAllRestaurants;

public class GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository,
    ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant with id ${request.Id}");
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync(request.Id);
        return mapper.Map<RestaurantDto>(restaurant);
    }
}
