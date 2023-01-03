using Newtonsoft.Json;

namespace SensorSimulator.Model;

public class Sensors
{
    [JsonProperty("Sensors")]
    public Sensor[] SensorsArray;
}