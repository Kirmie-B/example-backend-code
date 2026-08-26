using Garden.Models;
using System.Data;

namespace Garden.DataAccess.DataAccessObjects.Interfaces;

public interface IHardinessZoneDao
{
    /// <summary>
    /// Get all hardiness zones from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the hardiness zones.</returns>
    Task<List<HardinessZone>> GetAllHardinessZones(IDbTransaction dbTransaction);
}