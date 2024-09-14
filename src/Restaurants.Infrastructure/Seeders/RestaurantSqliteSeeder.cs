using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSqliteSeeder(RestaurantsSqliteDbContext restaurantsSqliteDbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await restaurantsSqliteDbContext.Database.CanConnectAsync())
        {
            //if (!restaurantsSqliteDbContext.Restaurants.Any())
            //{
            //    var restaurants = GetRestaurants();
            //    restaurantsSqliteDbContext.Restaurants.AddRange(restaurants);
            //    await restaurantsSqliteDbContext.SaveChangesAsync();
            //}

            if (!restaurantsSqliteDbContext.Roles.Any())
            {
                var roles = GetRoles();
                restaurantsSqliteDbContext.Roles.AddRange(roles);
                await restaurantsSqliteDbContext.SaveChangesAsync();
            }

        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles = [
            new (UserRoles.User)
            {
                NormalizedName = UserRoles.User.ToUpper()
            },
            new (UserRoles.Owner)
            {
                NormalizedName = UserRoles.Owner.ToUpper()
            },
            new (UserRoles.Admin)
            {
                NormalizedName = UserRoles.Admin.ToUpper()
            }
        ];

        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new(){
                Name = "KFC",
                Category = "Fast Food",
                Description = "Finger lickin' good!",
                ContactEmail = "kfc@kfc.com",
                HasDelivery = true,
                Dishes = [
                    new(){
                        Name = "Fried Chicken 1",
                        Description = "Fried Chicken 1!",
                        Price = 10,
                    },
                    new(){
                        Name = "Fried Chicken 2",
                        Description = "Fried Chicken 2!",
                        Price = 20,
                    },
                ],
                Address = new() {
                    City = "Recife",
                    PostalCode = "50920-525",
                    Street = "Av. Padre Ibiapina"
                }
            },
            new(){
                Name = "McDonalds",
                Category = "Fast Food",
                Description = "I'm lovin' it!",
                ContactEmail = "mcdonalds@mcdonalds.com",
                HasDelivery = true,
                Dishes = [
                    new(){
                        Name = "BigMac",
                        Description = "BigMac!",
                        Price = 10,
                    },
                    new(){
                        Name = "McFish",
                        Description = "McFish!",
                        Price = 20,
                    },
                ],
                Address = new() {
                    City = "Recife 2",
                    PostalCode = "50920-525-2",
                    Street = "Av. Padre Ibiapina 2"
                }
            },
        ];
        return restaurants;
    }
}