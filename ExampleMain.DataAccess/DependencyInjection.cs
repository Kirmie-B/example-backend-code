using Microsoft.Extensions.DependencyInjection;
using ExampleMain.DataAccess.DataAccessObjects;
using ExampleMain.DataAccess.DataAccessObjects.Interfaces;

namespace ExampleMain.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessObjects(this IServiceCollection services)
    {
        services.AddScoped<IPlantTypeDao, PlantTypeDao>();
        
        return services;
    }
}