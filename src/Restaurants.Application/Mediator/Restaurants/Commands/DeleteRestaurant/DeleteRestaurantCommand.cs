using MediatR;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand: IRequest<RestaurantDto>
{
    public int Id { get; set; }
}
