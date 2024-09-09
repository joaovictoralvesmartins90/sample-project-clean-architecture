namespace Restaurants.Application.Users;

public record CurrentUser
{
    public string UserId { get; init; }
    public string Email { get; init; }
    public IEnumerable<string> Roles { get; init; }
    public bool IsInRoles(string RoleName)
    {
        return Roles.Contains(RoleName);
    }
}
