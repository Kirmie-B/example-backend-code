namespace Garden.Models;

/// <summary>
/// Model class representing a scientific classification family of plants.
/// </summary>
public class PlantFamily
{
    /// <summary>
    /// The unique identifier for the plant family.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The family name of a plant''s scientific classification.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Basic description of the plant family with examples.
    /// </summary>
    public string Description { get; set; }
}