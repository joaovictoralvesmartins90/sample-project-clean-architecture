using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Mediator.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
