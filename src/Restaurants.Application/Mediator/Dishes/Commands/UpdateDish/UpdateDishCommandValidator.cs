using FluentValidation;

namespace Restaurants.Application.Mediator.Dishes.Commands.UpdateDish;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateDishCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(r => r.Price).NotEmpty().GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(r => r.KiloCalories).NotEmpty().GreaterThan(0).WithMessage("Kilocalories must be greater than zero.");
    }
}
