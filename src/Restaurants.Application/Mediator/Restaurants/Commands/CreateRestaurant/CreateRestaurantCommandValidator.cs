using FluentValidation;

namespace Restaurants.Application.Mediator.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(r => r.Category).NotEmpty().WithMessage("Category is required.");
        RuleFor(r => r.ContactEmail).EmailAddress().WithMessage("Provide a valid email address.");
        RuleFor(r => r.ContactNumber).NotEmpty().WithMessage("Contact number is required.");
    }
}