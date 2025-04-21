namespace TurnBased_2D_Game;

using System.Xml.Serialization;

public class DefenceItemConfig
{
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("ReduceHitPoint")]
    public int ReduceHitPoint { get; set; }
    
    [XmlElement("Lootable")]
    public bool Lootable { get; set; }
    
    [XmlElement("Removable")]
    public bool Removable { get; set; }
}