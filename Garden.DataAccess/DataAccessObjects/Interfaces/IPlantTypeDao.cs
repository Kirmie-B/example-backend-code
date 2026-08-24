using System.Data;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface IPlantTypeDao
{
    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    Task GetAllPlantTypes(IDbTransaction dbTransaction);
}