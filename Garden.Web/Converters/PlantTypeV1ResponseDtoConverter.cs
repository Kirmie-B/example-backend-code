using Garden.DataTransferObjects;
using Garden.Models;
using System.Collections.Generic;
using System.Linq;

namespace Garden.Web.Converters;

/// <summary>
/// Class that is responsibel for the conversion of different types to <see cref="PlantTypeV1ResponseDto"/>. 
/// </summary>
public class PlantTypeV1ResponseDtoConverter
{
    /// <summary>
    /// Converts a <see cref="PlantType"/> model to a <see cref="PlantTypeV1ResponseDto"/>.  
    /// </summary>
    /// <param name="plantType">The <see cref="PlantType"/> model to convert.</param>
    /// <returns>A <see cref="PlantTypeV1ResponseDto"/> object.</returns>
    public static PlantTypeV1ResponseDto ConvertToDto(PlantType plantType)
    {
        var plantTypeDto = new PlantTypeV1ResponseDto
        {
            Id = plantType.Id,
            Name = plantType.Name,
            Description = plantType.Description,
            SunlightNeedIdPreferred = plantType.SunlightNeedIdPreferred,
            SunlightNeedIdTolerated = plantType.SunlightNeedIdTolerated,
            WaterNeedId = plantType.WaterNeedId,
            SoilPhMin = plantType.SoilPhMin,
            SoilPhMax = plantType.SoilPhMax,
            PlantFamilyId = plantType.PlantFamilyId,
            IsPerennial = plantType.IsPerennial,
            HardinessZoneIdMin = plantType.HardinessZoneIdMin,
            HardinessZoneIdMax = plantType.HardinessZoneIdMax
        };

        return plantTypeDto;
    }

    /// <summary>
    /// Converts a list of <see cref="PlantType"/> models to a list of <see cref="PlantTypeV1ResponseDto"/> objects.  
    /// </summary>
    /// <param name="plantTypes">The list of <see cref="PlantType"/> models to convert.</param>
    /// <returns>A list of <see cref="PlantTypeV1ResponseDto"/> objects.</returns>
    public static List<PlantTypeV1ResponseDto> ConvertToDtoList(List<PlantType> plantTypes)
    {
        var plantTypeDtos = plantTypes.Select(ConvertToDto).ToList();

        return plantTypeDtos;
    }
}