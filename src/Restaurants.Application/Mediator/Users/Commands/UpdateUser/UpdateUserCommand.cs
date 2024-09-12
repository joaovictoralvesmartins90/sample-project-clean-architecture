using MediatR;
using System.Text.Json.Serialization;

namespace Restaurants.Application.Mediator.Users.Commands;

public class UpdateUserCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    [JsonIgnore]
    public string? UserId { get; set; }
}
