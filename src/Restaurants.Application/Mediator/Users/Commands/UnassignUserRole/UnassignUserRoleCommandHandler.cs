using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Mediator.Users.Commands.AssignUserRole;

public class UnassignUserRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(request.RoleName);
        var user = await userManager.FindByEmailAsync(request.UserEmail);

        if (role == null)
        {
            throw new NotFoundException("Role not found.");
        }

        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        await userManager.RemoveFromRoleAsync(user, role.Name);

    }
}