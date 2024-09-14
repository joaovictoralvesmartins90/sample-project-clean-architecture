using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Mediator.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Mediator.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Mediator.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Mediator.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
[Authorize]
public class RestaurantsController(IMediator mediator,
    IValidator<CreateRestaurantCommand> validator,
    IValidator<UpdateRestaurantCommand> updateValidator) : ControllerBase
{

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand createRestaurantCommand)
    {
        ValidationResult result = await validator.ValidateAsync(createRestaurantCommand);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        else
        {
            var userId = User.FindFirstValue
            int id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(CreateRestaurant), new { id }, null);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand updateRestaurantCommand)
    {
        updateRestaurantCommand.Id = id;
        ValidationResult result = await updateValidator.ValidateAsync(updateRestaurantCommand);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        else
        {
            await mediator.Send(updateRestaurantCommand);
            return NoContent();
        }
    }

}