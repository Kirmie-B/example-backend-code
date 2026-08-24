using Microsoft.Extensions.DependencyInjection;
using Garden.Services.Interfaces;

namespace Garden.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPlantTypeService, PlantTypeService>();
        
        return services;
    }
}