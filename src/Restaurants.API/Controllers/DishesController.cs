using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Mediator.Dishes.Commands.CreateDish;
using Restaurants.Application.Mediator.Dishes.Commands.DeleteDish;
using Restaurants.Application.Mediator.Dishes.Queries.GetAllDishesFromRestaurant;
using Restaurants.Application.Mediator.Dishes.Queries.GetDishByIdFromRestaurant;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("/api/restaurants/{restaurantId}/dishes")]
    public class DishesController(IMediator mediator, IValidator<CreateDishCommand> validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand createDishCommand)
        {
            ValidationResult validationResult = validator.Validate(createDishCommand);
            if (validationResult.IsValid)
            {
                createDishCommand.RestaurantId = restaurantId;
                int dishId = await mediator.Send(createDishCommand);
                return CreatedAtAction(nameof(CreateDish), new { dishId }, null);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishesFromRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesFromRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<IActionResult> GetDishByFromRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdFromRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteDishFromRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            await mediator.Send(new DeleteDishCommand(restaurantId, dishId));
            return NoContent();
        }
    }
}
