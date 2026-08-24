using Dapper;
using Garden.DataAccess;
using Garden.DataAccess.DataAccessObjects.Interfaces;
using Garden.Models;
using Garden.Services.Interfaces;

namespace Garden.Services;

/// <summary>
/// Service class for handling operations related to plant types.
/// </summary>
public class PlantTypeService : IPlantTypeService
{
    private readonly IPlantTypeDao _plantTypeDao;
    private readonly DapperDbContext _dbContext;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantTypeService(IPlantTypeDao plantTypeDao, DapperDbContext dbContext)
    {
        _plantTypeDao = plantTypeDao;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all plant types from the database.
    /// </summary>
    /// <returns>A list containing all of the plant types.</returns>
    public async Task<List<PlantType>> GetAllPlantTypes()
    {
        using var dbTransaction = _dbContext.DbConnection.BeginTransaction();
        var plantTypes = await _plantTypeDao.GetAllPlantTypes(dbTransaction);

        return plantTypes;
    }
}