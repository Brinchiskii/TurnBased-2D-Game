using System.Xml.Serialization;

namespace TurnBased2DGame;

/// <summary>
/// Represents an attack item that can be configured in the XML file.
/// </summary>
public class AttackItemConfig
{
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("Hit")]
    public int Hit { get; set; }
    
    [XmlElement("Range")]
    public int Range { get; set; }
    
    [XmlElement("Lootable")]
    public bool Lootable { get; set; }
    
    [XmlElement("Removable")]
    public bool Removable { get; set; }
}