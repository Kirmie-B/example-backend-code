using Garden.Models;
using System.Data;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface IPlantFamilyDao
{
    /// <summary>
    /// Get all plant families from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the plant families.</returns>
    Task<List<PlantFamily>> GetAllPlantFamilies(IDbTransaction dbTransaction);
}