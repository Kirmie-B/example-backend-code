using Garden.DataAccess.DataAccessObjects.Interfaces;
using System.Data;
using Dapper;
using Garden.Models;

namespace Garden.DataAccess.DataAccessObjects;

/// <summary>
/// Data access object (DAO) for database calls related to the plant_type table. 
/// </summary>
public class PlantTypeDao : IPlantTypeDao
{
    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <param name="dbTransaction">The database transaction to use for this call.</param>
    /// <returns>A list containing all of the plant types.</returns>
    public async Task<List<PlantType>> GetAllPlantTypes(IDbTransaction dbTransaction)
    {
        var sqlQuery = $@"
            SELECT 
                id AS {nameof(PlantType.Id)},
                name AS {nameof(PlantType.Name)},
                description AS {nameof(PlantType.Description)},
                sunlight_need_id_preferred AS {nameof(PlantType.SunlightNeedIdPreferred)},
                sunlight_need_id_tolerated AS {nameof(PlantType.SunlightNeedIdTolerated)},
                water_need_id AS {nameof(PlantType.WaterNeedId)},
                soil_ph_min AS {nameof(PlantType.SoilPhMin)},
                soil_ph_max AS {nameof(PlantType.SoilPhMax)},
                plant_family_id AS {nameof(PlantType.PlantFamilyId)},
                is_perennial AS {nameof(PlantType.IsPerennial)},
                hardiness_zone_id_min AS {nameof(PlantType.HardinessZoneIdMin)},
                hardiness_zone_id_max AS {nameof(PlantType.HardinessZoneIdMax)}
            FROM plant_type";

        var plantTypes = await dbTransaction.Connection!.QueryAsync<PlantType>(sqlQuery);
        return plantTypes.ToList();
    }
}