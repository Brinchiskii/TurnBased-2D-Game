using System.Xml.Serialization;

namespace TurnBased2DGame;

/// <summary>
/// Provides static method for loading game configs from xml document
/// </summary>
/// <remarks>
/// This class uses <see cref="System.Xml.Serialization"/> to read the xml configs
/// </remarks>
public static class ConfigLoader
{
    /// <summary>
    /// Loads the game configs by using the GameConfig class to cast the values.
    /// </summary>
    /// <param name="path">The path for the xml config file</param>
    /// <returns>Returns a GameConfig object</returns>
    public static GameConfig Load(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
        using FileStream stream = new(path, FileMode.Open);
        return (GameConfig)serializer.Deserialize(stream);
    }
}