namespace Garden.Models;

/// <summary>
/// Model class representing the sunlight needs of a plant.
/// </summary>
public class SunlightNeed
{
    /// <summary>
    /// The unique identifier for the sunlight need.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The display name of the sunlight need.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A brief description of the sunlight need.
    /// </summary>
    public string Description { get; set; }
}