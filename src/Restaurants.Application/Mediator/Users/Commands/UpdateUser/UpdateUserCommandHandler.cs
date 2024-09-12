using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Mediator.Users.Commands;

public class UpdateUserCommandHandler(UserManager<User> userManager) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            throw new NotFoundException($"User with id {request.UserId}  not found.");
        }

        user.DateOfBirth = request.DateOfBirth;
        user.Nationality = request.Nationality;

        await userManager.UpdateAsync(user);
    }
}
