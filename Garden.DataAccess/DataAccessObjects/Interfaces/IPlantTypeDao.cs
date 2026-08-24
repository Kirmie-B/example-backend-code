using System.Data;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface IPlantTypeDao
{
    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the plant types.</returns>
    Task<List<PlantType>> GetAllPlantTypes(IDbTransaction dbTransaction);
}