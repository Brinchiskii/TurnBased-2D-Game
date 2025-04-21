using System.Xml.Serialization;

namespace TurnBased_2D_Game;

public class CreatureConfig
{
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("HitPoint")] 
    public int HitPoint { get; set; }
}