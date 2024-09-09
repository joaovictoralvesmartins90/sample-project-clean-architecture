using MediatR;
using Restaurants.Application.Users;

namespace Restaurants.Application.Mediator.Users;

public class GetUserQuery: IRequest<UserInfo>{
    public GetUserQuery(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
}