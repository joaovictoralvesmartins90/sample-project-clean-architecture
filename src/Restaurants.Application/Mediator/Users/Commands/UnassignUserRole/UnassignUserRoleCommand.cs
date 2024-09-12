using MediatR;

namespace Restaurants.Application.Mediator.Users.Commands.AssignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; }
    public string RoleName { get; set; }
}