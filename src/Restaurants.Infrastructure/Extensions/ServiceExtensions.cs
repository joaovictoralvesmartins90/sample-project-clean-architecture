using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static void AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("development");
        // services.AddDbContext<RestaurantsDbContext>(
        //     options => options.UseMySQL(connectionString)
        // );
        services.AddDbContext<RestaurantsSqliteDbContext>();
        //services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantSeeder, RestaurantSqliteSeeder>();
        //services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
        services.AddScoped<IRestaurantsRepository, RestaurantsSqliteRepository>();
        services.AddScoped<IDishesRepository, DishesSqliteRepository>();
    }
}