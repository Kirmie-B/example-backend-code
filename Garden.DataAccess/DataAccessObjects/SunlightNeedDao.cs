using Garden.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the sunlight_need table. 
/// </summary>
public class SunlightNeedDao : ISunlightNeedDao
{
    /// <summary>
    /// Get all sunlight needs from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the sunlight needs.</returns>
    public async Task<List<SunlightNeed>> GetAllSunlightNeeds(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(SunlightNeed.Id)},
                name AS {nameof(SunlightNeed.Name)},
                description AS {nameof(SunlightNeed.Description)}
            FROM sunlight_need";

        var sunlightNeeds = await dbTransaction.Connection!.QueryAsync<SunlightNeed>(sqlQuery);
        return sunlightNeeds.ToList();
    }
}