using System.Runtime.Serialization;

namespace Garden.DataTransferObjects;

/// <summary>
/// Data transfer object for V1 plant type responses.
/// </summary>
[DataContract]
public class PlantTypeV1ResponseDto
{
    /// <summary>
    /// The unique indentifier for the plant type.
    /// </summary>
    [DataMember]
    public Guid Id { get; set; }

    /// <summary>
    /// The display name of the plant type.
    /// </summary>
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// A brief description of the plant type.
    /// </summary>
    [DataMember]
    public string Description { get; set; }

    /// <summary>
    /// The ID of the preferred sunlight need for this plant type.
    /// </summary>
    [DataMember]
    public int SunlightNeedIdPreferred { get; set; }

    /// <summary>
    /// The ID of the tolerated sunlight need for this plat type. Null if not available.
    /// </summary>
    [DataMember]
    public int? SunlightNeedIdTolerated { get; set; }

    /// <summary>
    /// The ID of the water need for this plant type.
    /// </summary>
    [DataMember]
    public int WaterNeedId { get; set; }

    /// <summary>
    /// The minimum soil pH that this plant type requires.
    /// </summary>
    [DataMember]
    public decimal SoilPhMin { get; set; }

    /// <summary>
    /// The maximum soil pH that this plant type requires.
    /// </summary>
    [DataMember]
    public decimal SoilPhMax { get; set; }

    /// <summary>
    /// The ID of the plant family that this plant type belongs to.
    /// </summary>
    [DataMember]
    public int PlantFamilyId { get; set; }

    /// <summary>
    /// A boolean indicating whether this plant type is perennial (true) or annual (false) in the continental United States.
    /// </summary>
    [DataMember]
    public bool IsPerennial { get; set; }

    /// <summary>
    /// The minimum hardiness zone that this plant type can survive in.
    /// </summary>
    [DataMember]
    public int HardinessZoneIdMin { get; set; }

    /// <summary>
    /// The maximum hardiness zone that this plant type can survive in.
    /// </summary>
    [DataMember]
    public int HardinessZoneIdMax { get; set; }
}