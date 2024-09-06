using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurants.Application.Extensions;

public static class ApplicationLayerExtensions
{
    public static void AddApplicationLayerExtensions(this IServiceCollection services)
    {
        var assembly = typeof(ApplicationLayerExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
    }
}