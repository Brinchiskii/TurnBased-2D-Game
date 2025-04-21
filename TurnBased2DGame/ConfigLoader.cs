using System.Xml.Serialization;

namespace TurnBased2DGame;

public static class ConfigLoader
{
    public static GameConfig Load(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
        using FileStream stream = new(path, FileMode.Open);
        return (GameConfig)serializer.Deserialize(stream);
    }
}