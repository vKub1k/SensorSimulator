using Newtonsoft.Json;

namespace SensorSimulator.Model;

/// <summary>
/// Class <c>Sensors</c> models a sensors with array of sensor.
/// </summary>
public class Sensors
{
    [JsonProperty("Sensors")]
    public Sensor[] SensorsArray;
}