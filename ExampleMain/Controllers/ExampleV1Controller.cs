using Microsoft.AspNetCore.Mvc;

namespace ExampleMain.Controllers;

/// <summary>
/// Version 1 controller for Example related endpoints.
/// </summary>
[ApiController]
[Route("api/v1/example")]
public class ExampleV1Controller : ControllerBase
{
    /// <summary>
    /// My first example controller endpoint API.
    /// </summary>
    /// <returns>A random integer.</returns>
    [HttpGet("random-number")]
    public int GetRandomNumber()
    {
        var random = new Random();

        return random.Next();
    }
}
