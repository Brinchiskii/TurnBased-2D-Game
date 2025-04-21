using System.Xml.Serialization;

namespace TurnBased2DGame;

public class CreatureConfig
{
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("HitPoint")] 
    public int HitPoint { get; set; }
}