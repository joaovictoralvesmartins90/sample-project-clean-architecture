using MediatR;

namespace Restaurants.Application.Mediator.Dishes.Commands;

public class UpdateDishCommand : IRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }
    public int RestaurantId { get; set; }
    public int DishId { get; set; }
}