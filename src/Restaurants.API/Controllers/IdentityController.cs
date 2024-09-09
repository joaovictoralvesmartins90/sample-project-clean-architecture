using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Mediator.Users.Commands;
using Restaurants.Domain.Entities;
using System.Security.Claims;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        updateUserCommand.UserId = userId;
        await mediator.Send(updateUserCommand);
        return NoContent();
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync().ConfigureAwait(false);
        return Ok();
    }
}
