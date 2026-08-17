using Microsoft.AspNetCore.Mvc;

namespace ExampleMain.Controllers;

/// <summary>
/// Version 1 controller for Example related endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExampleV1Controller : ControllerBase
{
    /// <summary>
    /// My first example controller endpoint API.
    /// </summary>
    /// <returns>A random integer.</returns>
    [HttpGet(Name = "GetRandomNumber")]
    public int GetRandomNumber()
    {
        var random = new Random();

        return random.Next();
    }
}
