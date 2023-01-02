using Newtonsoft.Json;
using SensorSimulator.Model;

namespace SensorSimulator.Controller;

public class JsonController
{
    public static List<Sensor>? ReadFrom(string jsonPath)
    {
        var streamReader = new StreamReader(jsonPath);
        var json = streamReader.ReadToEnd();
        var result = JsonConvert.DeserializeObject<List<Sensor>>(json); //TODO Change code to suit JSON struct
        return result;
    }
}