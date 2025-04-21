using System.Xml.Serialization;

namespace TurnBased2DGame;

/// <summary>
/// Represents a creature's configuration as defined in the XML config file.
/// </summary>
public class CreatureConfig
{
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("HitPoint")] 
    public int HitPoint { get; set; }
}