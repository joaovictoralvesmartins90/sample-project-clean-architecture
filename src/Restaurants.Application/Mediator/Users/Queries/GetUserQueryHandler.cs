using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Mediator.Users.Queries;

public class GetUserQueryHandler(UserManager<User> userHandler) : IRequestHandler<GetUserQuery, CurrentUser>
{
    public async Task<CurrentUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        User user = await userHandler.FindByIdAsync(request.UserId);

        if (user == null)
        {
            throw new NotFoundException($"User with id {request.UserId}  not found.");
        }

        IEnumerable<string> rolesList = await userHandler.GetRolesAsync(user);
        return new CurrentUser { UserId = user.Id, Email = user.Email, Roles = rolesList };
    }
}
