using Garden.Models;

namespace Garden.Services.Interfaces;

/// <summary>
/// Interface for the <see cref="PlantTypeService"/> class. 
/// </summary>
public interface IPlantTypeService
{
    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <returns>A list containing all of the plant types.</returns>
    Task<List<PlantType>> GetAllPlantTypes();
}