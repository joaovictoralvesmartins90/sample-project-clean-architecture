using Restaurants.API.Middlewares;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using Serilog;
using Serilog.Events;

namespace Restaurants.API.Extensions;

public static class PresentationLayerExtensions
{
    public static void AddPresentationLayerExtensions(this IServiceCollection services, IHostBuilder host)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<TimeLoggingMiddleware>();
        host.UseSerilog((context, configuration) =>
        {
            configuration
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
                .WriteTo.Console();
        });
        services.AddAuthentication();
        services
            .AddIdentityApiEndpoints<User>()
            .AddEntityFrameworkStores<RestaurantsSqliteDbContext>();
    }
}
