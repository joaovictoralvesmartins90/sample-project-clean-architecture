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
        services.AddDbContext<RestaurantsSqliteDbContext>();
        services.AddScoped<IRestaurantSeeder, RestaurantSqliteSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsSqliteRepository>();
        services.AddScoped<IDishesRepository, DishesSqliteRepository>();
    }
}