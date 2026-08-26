using Garden.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the hardiness_zone table. 
/// </summary>
public class HardinessZoneDao : IHardinessZoneDao
{
    /// <summary>
    /// Get all hardiness zones from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the hardiness zones.</returns>
    public async Task<List<HardinessZone>> GetAllHardinessZones(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(HardinessZone.Id)},
                name AS {nameof(HardinessZone.Name)},
                description AS {nameof(HardinessZone.Description)}
            FROM hardiness_zone";

        var hardinessZones= await dbTransaction.Connection!.QueryAsync<HardinessZone>(sqlQuery);
        return hardinessZones.ToList();
    }
}