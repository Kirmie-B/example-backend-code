using Garden.Models;
using System.Data;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface ISunlightNeedDao
{
    /// <summary>
    /// Get all sunlight needs from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the sunlight needs.</returns>
    Task<List<SunlightNeed>> GetAllSunlightNeeds(IDbTransaction dbTransaction);
}