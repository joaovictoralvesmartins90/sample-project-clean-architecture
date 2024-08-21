using MediatR;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Mediator.Restaurants.Queries.GetAllRestaurants;

public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
{
    public GetRestaurantByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; }
}
