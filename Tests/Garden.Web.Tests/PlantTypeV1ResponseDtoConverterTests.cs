using Garden.Models;
using Garden.Web.Converters;

namespace Garden.Web.Tests;

/// <summary>
/// Class containing unit tests for the <see cref="PlantTypeV1ResponseDtoConverter"/> class. 
/// </summary>
[TestFixture]
public class PlantTypeV1ResponseDtoConverterTests
{
    #region ConvertToDto Tests

    /// <summary>
    /// Test to verify that <see cref="PlantTypeV1ResponseDtoConverter.ConvertToDto"/> returns the correct <see cref="PlantTypeV1ResponseDto"/>
    /// when given a valid <see cref="PlantType"/> model with all properties set.   
    /// </summary>
    [Test]
    public async Task ConvertToDto_ReturnCorrectDto_SuccessTest()
    {
        #region Setup

        var id = Guid.NewGuid();
        var name = "Test Plant Type";
        var description = "Test description";
        var sunlightNeedIdPreferred = 2;
        var sunlightNeedIdTolerated = 3;
        var waterNeedId = 2;
        var soilPhMin = 3.6m;
        var soilPhMax = 9.1m;
        var plantFamilyId = 8;
        var isPerennial = true;
        var hardinessZoneIdMin = 3;
        var hardinessZoneIdMax = 22;

        var plantType = new PlantType
        {
            Id = id,
            Name = name,
            Description = description,
            SunlightNeedIdPreferred = sunlightNeedIdPreferred,
            SunlightNeedIdTolerated = sunlightNeedIdTolerated,
            WaterNeedId = waterNeedId,
            SoilPhMin = soilPhMin,
            SoilPhMax = soilPhMax,
            PlantFamilyId = plantFamilyId,
            IsPerennial = isPerennial,
            HardinessZoneIdMin = hardinessZoneIdMin,
            HardinessZoneIdMax = hardinessZoneIdMax
        };

        #endregion Setup

        var result = PlantTypeV1ResponseDtoConverter.ConvertToDto(plantType);

        Assert.That(result, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo(name));
            Assert.That(result.Description, Is.EqualTo(description));
            Assert.That(result.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred));
            Assert.That(result.SunlightNeedIdTolerated, Is.EqualTo(sunlightNeedIdTolerated));
            Assert.That(result.WaterNeedId, Is.EqualTo(waterNeedId));
            Assert.That(result.SoilPhMin, Is.EqualTo(soilPhMin));
            Assert.That(result.SoilPhMax, Is.EqualTo(soilPhMax));
            Assert.That(result.PlantFamilyId, Is.EqualTo(plantFamilyId));
            Assert.That(result.IsPerennial, Is.EqualTo(isPerennial));
            Assert.That(result.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin));
            Assert.That(result.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax));
        });        
    }

    /// <summary>
    /// Test to verify that <see cref="PlantTypeV1ResponseDtoConverter.ConvertToDto"/> returns the correct <see cref="PlantTypeV1ResponseDto"/>
    /// when given a valid <see cref="PlantType"/> model with only required properties set.   
    /// </summary>
    [Test]
    public async Task ConvertToDto_ReturnCorrectDto_RequiredPropertiesOnly_SuccessTest()
    {
        #region Setup

        var id = Guid.NewGuid();
        var name = "Test Plant Type 2";
        var description = "Test description 2";
        var sunlightNeedIdPreferred = 3;
        var waterNeedId = 1;
        var soilPhMin = 2.5m;
        var soilPhMax = 8.0m;
        var plantFamilyId = 4;
        var isPerennial = false;
        var hardinessZoneIdMin = 7;
        var hardinessZoneIdMax = 18;

        var plantType = new PlantType
        {
            Id = id,
            Name = name,
            Description = description,
            SunlightNeedIdPreferred = sunlightNeedIdPreferred,
            WaterNeedId = waterNeedId,
            SoilPhMin = soilPhMin,
            SoilPhMax = soilPhMax,
            PlantFamilyId = plantFamilyId,
            IsPerennial = isPerennial,
            HardinessZoneIdMin = hardinessZoneIdMin,
            HardinessZoneIdMax = hardinessZoneIdMax
        };

        #endregion Setup

        var result = PlantTypeV1ResponseDtoConverter.ConvertToDto(plantType);

        Assert.That(result, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Name, Is.EqualTo(name));
            Assert.That(result.Description, Is.EqualTo(description));
            Assert.That(result.SunlightNeedIdPreferred, Is.EqualTo(sunlightNeedIdPreferred));
            Assert.That(result.SunlightNeedIdTolerated, Is.Null);
            Assert.That(result.WaterNeedId, Is.EqualTo(waterNeedId));
            Assert.That(result.SoilPhMin, Is.EqualTo(soilPhMin));
            Assert.That(result.SoilPhMax, Is.EqualTo(soilPhMax));
            Assert.That(result.PlantFamilyId, Is.EqualTo(plantFamilyId));
            Assert.That(result.IsPerennial, Is.EqualTo(isPerennial));
            Assert.That(result.HardinessZoneIdMin, Is.EqualTo(hardinessZoneIdMin));
            Assert.That(result.HardinessZoneIdMax, Is.EqualTo(hardinessZoneIdMax));
        });        
    }

    #endregion ConvertToDto Tests

    #region ConvertToDtoList Tests

    /// <summary>
    /// Test to verify that <see cref="PlantTypeV1ResponseDtoConverter.ConvertToDtoList"/> returns the correct list of 
    /// <see cref="PlantTypeV1ResponseDto"/> when given valid <see cref="PlantType"/> models.   
    /// </summary>
    [Test]
    public async Task ConvertToDtoList_ReturnCorrectDtoList_SuccessTest()
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

        #endregion Setup

        var result = PlantTypeV1ResponseDtoConverter.ConvertToDtoList(plantTypes);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

        var plantTypeDto1 = result.SingleOrDefault(dto => dto.Id == id1);
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

        var plantTypeDto2 = result.SingleOrDefault(dto => dto.Id == id2);
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

    #endregion ConvertToDtoList Tests

}
