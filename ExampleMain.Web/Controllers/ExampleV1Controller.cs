using Microsoft.AspNetCore.Mvc;
using ExampleMain.Services.Interfaces;

namespace ExampleMain.Web.Controllers;

/// <summary>
/// Version 1 controller for Example related endpoints.
/// </summary>
[ApiController]
[Route("api/v1/example")]
public class ExampleV1Controller : ControllerBase
{
    private readonly IFirstService _firstService;

    /// <summary>
    /// Only constructor.
    /// </summary>
    public ExampleV1Controller(IFirstService firstService)
    {
        _firstService = firstService;
    }

    /// <summary>
    /// My first example controller endpoint API.
    /// </summary>
    /// <returns>A random integer.</returns>
    [HttpGet("random-number")]
    public async Task<int> GetRandomNumber()
    {
        var random = new Random();

        await _firstService.DoTheThing();

        return random.Next();
    }
}
