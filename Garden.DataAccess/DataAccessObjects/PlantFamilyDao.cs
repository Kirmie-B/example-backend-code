using Garden.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the plant_family table. 
/// </summary>
public class PlantFamilyDao : IPlantFamilyDao
{
    /// <summary>
    /// Get all plant families from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the plant families.</returns>
    public async Task<List<PlantFamily>> GetAllPlantFamilies(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(PlantFamily.Id)},
                name AS {nameof(PlantFamily.Name)},
                description AS {nameof(PlantFamily.Description)}
            FROM plant_families";

        var plantFamilies= await dbTransaction.Connection!.QueryAsync<PlantFamily>(sqlQuery);
        return plantFamilies.ToList();
    }
}