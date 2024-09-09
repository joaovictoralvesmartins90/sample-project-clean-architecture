using MediatR;
using Microsoft.AspNetCore.Identity;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mediator.Users.Queries;

public class GetUserQueryHandler(UserManager<User> userHandler) : IRequestHandler<GetUserQuery, UserInfo>
{
    public async Task<UserInfo> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        User user = await userHandler.FindByIdAsync(request.UserId);
        IEnumerable<string> rolesList = await userHandler.GetRolesAsync(user);

        //Using microsoft identity core, how to pass user information from the controller, to the application layer using cqrs?

        return new UserInfo {
            UserId = user.Id,
            Email = user.Email,
            Roles = rolesList
        };

    }
}
