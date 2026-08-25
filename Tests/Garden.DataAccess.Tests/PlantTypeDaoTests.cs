using Dapper;
using Garden.DataAccess.DataAccessObjects;
using Garden.Models;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Data.Common;

namespace Garden.DataAccess.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="PlantTypeDao"/> class.
/// </summary>
[TestFixture]
public class PlantTypeDaoTests
{
    private PlantTypeDao _plantTypeDao;

    private readonly Mock<IDbTransaction> _dbTransactionMock;
    private readonly Mock<DbConnection> _dbConnectionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantTypeDaoTests()
    {
        _dbTransactionMock = new Mock<IDbTransaction>();
        _dbConnectionMock = new Mock<DbConnection>();

        _dbTransactionMock.Setup(mock => mock.Connection).Returns(_dbConnectionMock.Object);

        _plantTypeDao = new PlantTypeDao();
    }

    #region GetAllPlantTypes Tests

    /// <summary>
    /// Tests that <see cref="PlantTypeDao.GetAllPlantTypes"/> returns all plant types succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllPlantTypes_ReturnsAllPlantTypes_SuccessTest()
    {
        #region Setup

        var id1 = Guid.NewGuid();
        var name1 = "Test Plant Type";
        var description1 = "Test description";
        var sunlightNeedIdPreferred1 = 2;
        var sunlightNeedIdTolerated1 = 3;
        var waterNeedId1= 2;
        var soilPhMin1 = 3.6m;
        var soilPhMax1 = 9.1m;
        var plantFamilyId1 = 8;
        var isPerennial1 = true;
        var hardinessZoneIdMin1 = 3;
        var hardinessZoneIdMax1 = 22;

        var plantType1 = new PlantType
        {
            Id = id1,
            Name = name1,
            Description = description1,
            SunlightNeedIdPreferred = sunlightNeedIdPreferred1,
            SunlightNeedIdTolerated = sunlightNeedIdTolerated1,
            WaterNeedId = waterNeedId1,
            SoilPhMin = soilPhMin1,
            SoilPhMax = soilPhMax1,
            PlantFamilyId = plantFamilyId1,
            IsPerennial = isPerennial1,
            HardinessZoneIdMin = hardinessZoneIdMin1,
            HardinessZoneIdMax = hardinessZoneIdMax1
        };


        var id2 = Guid.NewGuid();
        var name2 = "Test Plant Type 2";
        var description2 = "Test description 2";
        var sunlightNeedIdPreferred2 = 3;
        var waterNeedId2 = 1;
        var soilPhMin2 = 2.5m;
        var soilPhMax2 = 8.0m;
        var plantFamilyId2 = 4;
        var isPerennial2 = false;
        var hardinessZoneIdMin2 = 7;
        var hardinessZoneIdMax2 = 18;

        var plantType2 = new PlantType
        {
            Id = id2,
            Name = name2,
            Description = description2,
            SunlightNeedIdPreferred = sunlightNeedIdPreferred2,
            WaterNeedId = waterNeedId2,
            SoilPhMin = soilPhMin2,
            SoilPhMax = soilPhMax2,
            PlantFamilyId = plantFamilyId2,
            IsPerennial = isPerennial2,
            HardinessZoneIdMin = hardinessZoneIdMin2,
            HardinessZoneIdMax = hardinessZoneIdMax2
        };

        var plantTypes = new List<PlantType>{plantType2, plantType1};

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

        _dbConnectionMock.SetupDapperAsync(mock => mock.QueryAsync<PlantType>(sqlQuery)).ReturnsAsync(plantTypes);

        #endregion Setup

        var result = await _plantTypeDao.GetAllPlantTypes(_dbTransactionMock.Object);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var plantType1Result = result.SingleOrDefault(plantType => plantType.Id == id1);
        Assert.That(plantType1Result, Is.Not.Null, "The first PlantType was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantType1Result.Id, Is.EqualTo(id1));
            Assert.That(plantType1Result.Name, Is.EqualTo(name1));
            Assert.That(plantType1Result.Description, Is.EqualTo(description1));
            Assert.That(plantType1Result.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred1));
            Assert.That(plantType1Result.SunlightNeedIdTolerated, Is.EqualTo(sunlightNeedIdTolerated1));
            Assert.That(plantType1Result.WaterNeedId, Is.EqualTo(waterNeedId1));
            Assert.That(plantType1Result.SoilPhMin, Is.EqualTo(soilPhMin1));
            Assert.That(plantType1Result.SoilPhMax, Is.EqualTo(soilPhMax1));
            Assert.That(plantType1Result.PlantFamilyId, Is.EqualTo(plantFamilyId1));
            Assert.That(plantType1Result.IsPerennial, Is.EqualTo(isPerennial1));
            Assert.That(plantType1Result.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin1));
            Assert.That(plantType1Result.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax1));
        });

        var plantType2Result = result.SingleOrDefault(plantType => plantType.Id == id2);
        Assert.That(plantType2Result, Is.Not.Null, "The second PlantType was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantType2Result.Id, Is.EqualTo(id2));
            Assert.That(plantType2Result.Name, Is.EqualTo(name2));
            Assert.That(plantType2Result.Description, Is.EqualTo(description2));
            Assert.That(plantType2Result.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred2));
            Assert.That(plantType2Result.SunlightNeedIdTolerated, Is.Null);
            Assert.That(plantType2Result.WaterNeedId, Is.EqualTo(waterNeedId2));
            Assert.That(plantType2Result.SoilPhMin, Is.EqualTo(soilPhMin2));
            Assert.That(plantType2Result.SoilPhMax, Is.EqualTo(soilPhMax2));
            Assert.That(plantType2Result.PlantFamilyId, Is.EqualTo(plantFamilyId2));
            Assert.That(plantType2Result.IsPerennial, Is.EqualTo(isPerennial2));
            Assert.That(plantType2Result.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin2));
            Assert.That(plantType2Result.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax2));
        });
    }

    #endregion GetAllPlantTypes Tests
}
