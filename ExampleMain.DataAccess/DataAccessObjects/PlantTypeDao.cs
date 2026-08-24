using ExampleMain.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
namespace ExampleMain.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the plant_type table. 
/// </summary>
public class PlantTypeDao : IPlantTypeDao
{
    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    public async Task GetAllPlantTypes(IDbTransaction dbTransaction)
    {
        var result = await dbTransaction.Connection!.QueryAsync("SELECT * FROM plant_type");
    }
}