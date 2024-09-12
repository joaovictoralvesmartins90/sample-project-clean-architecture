using MediatR;

namespace Restaurants.Application.Mediator.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; }
    public string RoleName { get; set; }
}