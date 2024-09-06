using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class InfrastructureLayerExtensions
{
    public static void AddInfrastructureLayerExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("development");
        services.AddDbContext<RestaurantsDbContext>(
            options => options.UseMySQL(connectionString)
        );
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();
    }

    public static void AddInfrastructureLayerExtensionsSqlite(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsSqliteDbContext>();
        services.AddScoped<IRestaurantSeeder, RestaurantSqliteSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsSqliteRepository>();
        services.AddScoped<IDishesRepository, DishesSqliteRepository>();
    }
}