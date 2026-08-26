using Garden.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the water_need table. 
/// </summary>
public class WaterNeedDao : IWaterNeedDao
{
    /// <summary>
    /// Get all wter needs from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the Water needs.</returns>
    public async Task<List<WaterNeed>> GetAllWaterNeeds(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(WaterNeed.Id)},
                name AS {nameof(WaterNeed.Name)},
                description AS {nameof(WaterNeed.Description)}
            FROM Water_need";

        var waterNeeds = await dbTransaction.Connection!.QueryAsync<WaterNeed>(sqlQuery);
        return waterNeeds.ToList();
    }
}