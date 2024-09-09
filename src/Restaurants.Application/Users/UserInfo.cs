namespace Restaurants.Application.Users;

public class UserInfo{

    public UserInfo(string userId, string email, IEnumerable<string> roles)
    {
        UserId = userId;
        Email = email;
        Roles = roles;
    }

    public bool IsInRoles(string role){
        return Roles.Contains(role);
    }

    public string UserId { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles { get; set; }
}