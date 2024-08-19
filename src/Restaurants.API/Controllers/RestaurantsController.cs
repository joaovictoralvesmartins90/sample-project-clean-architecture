using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsServices restaurantsServices, IValidator<CreateRestaurantDto> validator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsServices.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantsServices.GetRestaurantById(id);
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
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        ValidationResult result = await validator.ValidateAsync(createRestaurantDto);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        else
        {
            int id = await restaurantsServices.Create(createRestaurantDto);
            return CreatedAtAction(nameof(CreateRestaurant), new { id }, null);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var restaurant = await restaurantsServices.GetRestaurantById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        else
        {
            restaurantsServices.DeleteRestaurant(id);
            return NoContent();
        }
    }

}