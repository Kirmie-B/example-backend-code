namespace Garden.Models;

/// <summary>
/// Model class representing the water needs of a plant.
/// </summary>
public class WaterNeed
{
    /// <summary>
    /// The unique identifier for the water need.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The display name of the water need.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A brief description of the water need.
    /// </summary>
    public string Description { get; set; }
}