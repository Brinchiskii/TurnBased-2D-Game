using System.Xml.Serialization;

namespace TurnBased2DGame;

[XmlRoot("GameConfig")]
public class GameConfig
{
    [XmlElement("WorldSizeX")]
    public int WorldSizeX { get; set; }
    
    [XmlElement("WorldSizeY")]
    public int WorldSizeY { get; set; }
    
    [XmlElement("GameLevel")]
    public string GameLevel { get; set; }
    
    [XmlArray("Creatures")]
    [XmlArrayItem("Creature")]
    public List<CreatureConfig> Creatures { get; set; } = new();
    
    [XmlArray("AttackItems")]
    [XmlArrayItem("AttackItem")]
    public List<AttackItemConfig> AttackItems { get; set; } = new();
    
    [XmlArray("DefenceItems")]
    [XmlArrayItem("DefenceItem")]
    public List<DefenceItemConfig> DefenceItems { get; set; } = new();

}