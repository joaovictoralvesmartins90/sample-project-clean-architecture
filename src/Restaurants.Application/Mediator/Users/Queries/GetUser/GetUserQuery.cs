using MediatR;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Mediator.Users;

public class GetUserQuery: IRequest<CurrentUser>{
    public GetUserQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}