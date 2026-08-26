using Garden.DataAccess;
using Garden.DataAccess.DataAccessObjects.Interfaces;
using Garden.Models;
using Moq;
using System.Data;

namespace Garden.Services.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="PlantTypeService"/> class. 
/// </summary>
[TestFixture]
public class PlantTypeServiceTests
{
    private readonly PlantTypeService _plantTypeService;

    private readonly Mock<IDapperDbContext> _dapperDbContextMock;
    private readonly Mock<IPlantTypeDao> _plantTypeDaoMock;
    private readonly Mock<IDbConnection> _dbConnectionMock;
    private readonly Mock<IDbTransaction> _dbTransactionMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantTypeServiceTests()
    {
        _dapperDbContextMock = new Mock<IDapperDbContext>();
        _plantTypeDaoMock = new Mock<IPlantTypeDao>();
        _dbConnectionMock = new Mock<IDbConnection>();
        _dbTransactionMock = new Mock<IDbTransaction>();

        // Mock the database connection and transaction creation.
        _dapperDbContextMock.Setup(mock => mock.DbConnection).Returns(_dbConnectionMock.Object);
        _dbConnectionMock.Setup(mock => mock.BeginTransaction()).Returns(_dbTransactionMock.Object);

        _plantTypeService = new PlantTypeService(_plantTypeDaoMock.Object, _dapperDbContextMock.Object);
    }

    /// <summary>
    /// Function that is run after each test.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _dapperDbContextMock.VerifyAll();
        _dbTransactionMock.VerifyAll();
        _dbConnectionMock.VerifyAll();
        _plantTypeDaoMock.VerifyAll();     
    }

    #region GetAllPlantTypes Tests

    /// <summary>
    /// Tests that <see cref="PlantTypeService.GetAllPlantTypes"/> returns all plant types succesfully when multiple values are returned.
    /// </summary>
    [Test]
    public async Task GetAllPlantTypes_ReturnAllPlantTypes_SuccessTest()
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

        _plantTypeDaoMock.Setup(mock => mock.GetAllPlantTypes(_dbTransactionMock.Object)).ReturnsAsync(plantTypes).Verifiable(Times.Once);

        #endregion Setup

        var result = await _plantTypeService.GetAllPlantTypes();

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
        
        _plantTypeDaoMock.VerifyAll();
        _dbConnectionMock.Verify(mock => mock.BeginTransaction(), Times.Once);
    }

    #endregion GetAllPlantTypes Tests
}
