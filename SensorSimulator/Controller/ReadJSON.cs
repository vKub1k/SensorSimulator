using Newtonsoft.Json;
using SensorSimulator.Model;

namespace SensorSimulator.Controller;

/// <summary>
/// Class <c>JsonController</c> controller to work with JSON files.
/// </summary>
public class JsonController
{
    /// <summary>
    /// Method <c>ReadFrom</c> read JSON file.
    /// </summary>
    public static Sensors? ReadFrom(string jsonPath)
    {
        var streamReader = new StreamReader(jsonPath);
        var json = streamReader.ReadToEnd();
        var result = JsonConvert.DeserializeObject<Sensors>(json);
        return result;
    }
}