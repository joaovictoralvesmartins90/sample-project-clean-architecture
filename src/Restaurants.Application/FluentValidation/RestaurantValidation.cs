using FluentValidation;
using Restaurants.Application.Dtos;

namespace Restaurants.Application.FluentValidation;

public class RestaurantValidation : AbstractValidator<CreateRestaurantDto>
{
    public RestaurantValidation()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(r => r.Category).NotEmpty().WithMessage("Category is required.");
        RuleFor(r => r.ContactEmail).EmailAddress().WithMessage("Provide a valid email address.");
        RuleFor(r => r.ContactNumber).NotEmpty().WithMessage("Contact number is required.");
    }
}