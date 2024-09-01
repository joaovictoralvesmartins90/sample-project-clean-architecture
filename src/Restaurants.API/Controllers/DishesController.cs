using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Mediator.Dishes.Commands;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("/api/restaurants{restaurantId}/dishes")]
    public class DishesController(IMediator mediator, IValidator<CreateDishCommand> validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand createDishCommand)
        {
            ValidationResult validationResult = validator.Validate(createDishCommand);
            if (validationResult.IsValid)
            {
                int dishId = await mediator.Send(createDishCommand);
                return CreatedAtAction(nameof(CreateDish), new { dishId }, null);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }
    }
}
