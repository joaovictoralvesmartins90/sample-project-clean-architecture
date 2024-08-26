using FluentValidation;

namespace Restaurants.Application.Mediator.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandValidator: AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");
    }
}
