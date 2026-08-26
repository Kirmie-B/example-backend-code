namespace Garden.Models;

/// <summary>
/// Model class representing a United States Department of Agriculture hardiness zone.
/// </summary>
public class HardinessZone
{
    /// <summary>
    /// The unique identifier for the hardiness zone.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The display name of the hardiness zone. This is a number followed by a letter.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Full description of the hardiness zone with temperatures in Fahrenheit and Celsius.
    /// </summary>
    public string Description { get; set; }
}