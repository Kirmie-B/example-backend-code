using Microsoft.Extensions.DependencyInjection;
using ExampleMain.Services.Interfaces;

namespace ExampleMain.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPlantTypeService, PlantTypeService>();
        
        return services;
    }
}