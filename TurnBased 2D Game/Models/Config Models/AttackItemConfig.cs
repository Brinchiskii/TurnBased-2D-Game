using System.Xml.Serialization;

namespace TurnBased_2D_Game;

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