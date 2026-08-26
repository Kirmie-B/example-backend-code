using Garden.Models;
using System.Data;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface IWaterNeedDao
{
    /// <summary>
    /// Get all water needs from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the water needs.</returns>
    Task<List<WaterNeed>> GetAllWaterNeeds(IDbTransaction dbTransaction);
}