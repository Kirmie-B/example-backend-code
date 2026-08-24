using Garden.DataTransferObjects;
using Garden.Services.Interfaces;
using Garden.Web.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Web.Controllers;

/// <summary>
/// Version 1 controller for plant type related endpoints.
/// </summary>
[ApiController]
[Route("api/v1/plant-types")]
public class PlantTypeV1Controller : ControllerBase
{
    private readonly IPlantTypeService _plantTypeService;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public PlantTypeV1Controller(IPlantTypeService plantTypeService)
    {
        _plantTypeService = plantTypeService;
    }

    /// <summary>
    /// My first example controller endpoint API.
    /// </summary>
    /// <returns>A list of all plant types.</returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Returns a list of all plant types.")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Description = "No plant types were found.")]
    public async Task<ActionResult<List<PlantTypeV1ResponseDto>>> GetAllPlantTypes()
    {
        var plantTypes = await _plantTypeService.GetAllPlantTypes();

        // If no plant types were found, return a 204 No Content response.
        if(plantTypes.Count == 0)
            return NoContent();

        var plantTypeDtos = PlantTypeV1ResponseDtoConverter.ConvertToDtoList(plantTypes);

        return Ok(plantTypeDtos);
    }
}
