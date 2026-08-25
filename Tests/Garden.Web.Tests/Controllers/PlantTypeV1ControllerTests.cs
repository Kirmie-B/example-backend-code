using Garden.DataTransferObjects;
using Garden.Models;
using Garden.Services.Interfaces;
using Garden.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Garden.Web.Tests.Controllers;

[TestFixture]
public class PlantTypeV1ControllerTests
{
    private readonly PlantTypeV1Controller _plantTypeController;

    private readonly Mock<IPlantTypeService> _plantTypeServiceMock;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantTypeV1ControllerTests()
    {
        _plantTypeServiceMock = new Mock<IPlantTypeService>();

        _plantTypeController = new PlantTypeV1Controller(_plantTypeServiceMock.Object);
    }

    #region GetAllPlantTypes Tests

    /// <summary>
    /// Tests that <see cref="PlantTypeV1Controller.GetAllPlantTypes"/> returns an OK result with the correct values when data is found. 
    /// </summary>
    [Test]
    public async Task GetAllPlantTypes_ReturnsOK_SuccessTest()
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

        _plantTypeServiceMock.Setup(mock => mock.GetAllPlantTypes()).ReturnsAsync(plantTypes).Verifiable(Times.Once);

        #endregion Setup

        var result = await _plantTypeController.GetAllPlantTypes();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());

        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.Value, Is.Not.Null);
        Assert.That(okResult.Value, Is.TypeOf<List<PlantTypeV1ResponseDto>>());

        var plantTypeResults = okResult.Value as List<PlantTypeV1ResponseDto>;
        Assert.That(plantTypeResults, Is.Not.Null);
        Assert.That(plantTypeResults.Count, Is.EqualTo(2));

        var plantTypeDto1 = plantTypeResults.SingleOrDefault(dto => dto.Id == id1);
        Assert.That(plantTypeDto1, Is.Not.Null, "The first PlantTypeV1ResponseDto was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantTypeDto1.Id, Is.EqualTo(id1));
            Assert.That(plantTypeDto1.Name, Is.EqualTo(name1));
            Assert.That(plantTypeDto1.Description, Is.EqualTo(description1));
            Assert.That(plantTypeDto1.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred1));
            Assert.That(plantTypeDto1.SunlightNeedIdTolerated, Is.EqualTo(sunlightNeedIdTolerated1));
            Assert.That(plantTypeDto1.WaterNeedId, Is.EqualTo(waterNeedId1));
            Assert.That(plantTypeDto1.SoilPhMin, Is.EqualTo(soilPhMin1));
            Assert.That(plantTypeDto1.SoilPhMax, Is.EqualTo(soilPhMax1));
            Assert.That(plantTypeDto1.PlantFamilyId, Is.EqualTo(plantFamilyId1));
            Assert.That(plantTypeDto1.IsPerennial, Is.EqualTo(isPerennial1));
            Assert.That(plantTypeDto1.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin1));
            Assert.That(plantTypeDto1.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax1));
        });

        var plantTypeDto2 = plantTypeResults.SingleOrDefault(dto => dto.Id == id2);
        Assert.That(plantTypeDto2, Is.Not.Null, "The second PlantTypeV1ResponseDto was not found in the result list.");

        Assert.Multiple(() =>
        {
            Assert.That(plantTypeDto2.Id, Is.EqualTo(id2));
            Assert.That(plantTypeDto2.Name, Is.EqualTo(name2));
            Assert.That(plantTypeDto2.Description, Is.EqualTo(description2));
            Assert.That(plantTypeDto2.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred2));
            Assert.That(plantTypeDto2.SunlightNeedIdTolerated, Is.Null);
            Assert.That(plantTypeDto2.WaterNeedId, Is.EqualTo(waterNeedId2));
            Assert.That(plantTypeDto2.SoilPhMin, Is.EqualTo(soilPhMin2));
            Assert.That(plantTypeDto2.SoilPhMax, Is.EqualTo(soilPhMax2));
            Assert.That(plantTypeDto2.PlantFamilyId, Is.EqualTo(plantFamilyId2));
            Assert.That(plantTypeDto2.IsPerennial, Is.EqualTo(isPerennial2));
            Assert.That(plantTypeDto2.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin2));
            Assert.That(plantTypeDto2.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax2));
        });
    }

    /// <summary>
    /// Tests that <see cref="PlantTypeV1Controller.GetAllPlantTypes"/> returns a 204 No Content result when no data is found. 
    /// </summary>
    [Test]
    public async Task GetAllPlantTypes_ReturnsNoContent_WhenNoDataFound_SuccessTest()
    {
        #region Setup

        _plantTypeServiceMock.Setup(mock => mock.GetAllPlantTypes()).ReturnsAsync(new List<PlantType>()).Verifiable(Times.Once);

        #endregion Setup

        var result = await _plantTypeController.GetAllPlantTypes();
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Result, Is.TypeOf<NoContentResult>());

        _plantTypeServiceMock.VerifyAll();
    }

    #endregion GetAllPlantTypes Tests
}