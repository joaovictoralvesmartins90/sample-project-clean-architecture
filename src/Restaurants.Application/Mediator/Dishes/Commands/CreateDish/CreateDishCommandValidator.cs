using FluentValidation;

namespace Restaurants.Application.Mediator.Dishes.Commands.CreateDish;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(r => r.Price).NotEmpty().GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(r => r.KiloCalories).NotEmpty().GreaterThan(0).WithMessage("Kilocalories must be greater than zero.");
    }
}
