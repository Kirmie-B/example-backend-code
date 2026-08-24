using Microsoft.Extensions.DependencyInjection;
using Garden.DataAccess.DataAccessObjects;
using Garden.DataAccess.DataAccessObjects.Interfaces;

namespace Garden.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessObjects(this IServiceCollection services)
    {
        services.AddScoped<IPlantTypeDao, PlantTypeDao>();
        
        return services;
    }
}