namespace Garden.Models;

/// <summary>
/// Model class representing a type of plant.
/// </summary>
public class PlantType
{
	/// <summary>
	/// Unique identifier for the plant type.
	/// </summary>
    public Guid Id { get; set; }

	/// <summary>
	/// The display name of the plant type.
	/// </summary>
    public string Name { get; set; }

	/// <summary>
	/// A brief description of the plant type.
	/// </summary>
    public string Description { get; set; }

	/// <summary>
	/// The ID of the preferred sunlight need for the plant type.
	/// </summary>
    public int SunlightNeedIdPreferred { get; set; }

	/// <summary>
	/// The ID of the tolerated sunlight need for the plant type. Null if not available.
	/// </summary>
    public int? SunlightNeedIdTolerated { get; set; }

	/// <summary>
	/// The ID of the water need for the plant type.
	/// </summary>
	public int WaterNeedId { get; set; }

	/// <summary>
	/// The minimum soil pH that the plant type requires.
	/// </summary>
	public decimal SoilPhMin { get; set; }

	/// <summary>
	/// The maximum soil pH that the plant type requires.
	/// </summary>
	public decimal SoilPhMax { get; set; }

	/// <summary>
	/// The ID of the plant family that the plant type belongs to.
	/// </summary>
	public int PlantFamilyId { get; set; }

	/// <summary>
	/// Indicates whether the plant type is perennial.
	/// </summary>
	public bool IsPerennial { get; set; }

	/// <summary>
	/// The minimum hardiness zone that the plant type can survive in.
	/// </summary>
	public int HardinessZoneIdMin { get; set; }

	/// <summary>
	/// The maximum hardiness zone that the plant type can survive in.
	/// </summary>
	public int HardinessZoneIdMax { get; set; }
}