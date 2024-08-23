using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Mediator.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Mediator.Restaurants.Queries.GetAllRestaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IMediator mediator, IValidator<CreateRestaurantCommand> validator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (restaurant == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(restaurant);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
    {
        ValidationResult result = await validator.ValidateAsync(createRestaurantCommand);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        else
        {
            int id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(CreateRestaurant), new { id }, null);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));
        if (isDeleted)
        {
            return NoContent();
        }
        return NotFound();
    }

}