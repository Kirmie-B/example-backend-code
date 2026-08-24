using Microsoft.AspNetCore.Mvc;
using Garden.Services.Interfaces;

namespace Garden.Web.Controllers;

/// <summary>
/// Version 1 controller for Example related endpoints.
/// </summary>
[ApiController]
[Route("api/v1/example")]
public class ExampleV1Controller : ControllerBase
{
    private readonly IPlantTypeService _plantTypeService;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public ExampleV1Controller(IPlantTypeService plantTypeService)
    {
        _plantTypeService = plantTypeService;
    }

    /// <summary>
    /// My first example controller endpoint API.
    /// </summary>
    /// <returns>A random integer.</returns>
    [HttpGet("random-number")]
    public async Task<int> GetRandomNumber()
    {
        var random = new Random();

        var plantTypes = await _plantTypeService.GetAllPlantTypes();

        return random.Next();
    }
}
