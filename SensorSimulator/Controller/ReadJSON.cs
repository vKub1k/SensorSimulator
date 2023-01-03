using Newtonsoft.Json;
using SensorSimulator.Model;

namespace SensorSimulator.Controller;

public class JsonController
{
    public static Sensors ReadFrom(string jsonPath)
    {
        var streamReader = new StreamReader(jsonPath);
        var json = streamReader.ReadToEnd();
        return JsonConvert.DeserializeObject<Sensors>(json);
    }
}