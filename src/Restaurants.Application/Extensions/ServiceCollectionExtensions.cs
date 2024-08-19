using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddScoped<IRestaurantsServices, RestaurantsServices>();
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
    }
}