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
    private readonly IDapperWrapper _dapperWrapper;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public WaterNeedDao(IDapperWrapper dapperWrapper)
    {
        _dapperWrapper = dapperWrapper;
    }

    /// <summary>
    /// Get all water needs from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the water needs.</returns>
    public async Task<List<WaterNeed>> GetAllWaterNeeds(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(WaterNeed.Id)},
                name AS {nameof(WaterNeed.Name)},
                description AS {nameof(WaterNeed.Description)}
            FROM water_need";

        var waterNeeds = await _dapperWrapper.QueryAsync<WaterNeed>(dbTransaction.Connection!, sqlQuery);
        return waterNeeds.ToList();
    }
}