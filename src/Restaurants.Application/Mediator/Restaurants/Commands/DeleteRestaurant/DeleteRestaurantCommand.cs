using MediatR;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand: IRequest<bool>
{
    public DeleteRestaurantCommand(int id)
    {
        Id = id;
    }
    public int Id { get; init; }
}
