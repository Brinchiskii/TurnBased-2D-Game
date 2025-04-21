using System.Xml.Serialization;

namespace TurnBased2DGame;

/// <summary>
/// Represents configuration settings for initializing the game world.
/// </summary>
/// <remarks>
/// This class is populated by deserializing XML data from a config file.
/// It contains general game parameters and lists of initial creatures and objects.
/// </remarks>
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