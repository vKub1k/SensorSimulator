using Newtonsoft.Json;

namespace SensorSimulator.Model;

public class Sensor
{ 
    [JsonProperty("ID")] public int ID { get; set; }
    [JsonProperty("Type")] public string Type  { get; set; }
    [JsonProperty("MinValue")] public int MinValue  { get; set; }
    [JsonProperty("MaxValue")] public int MaxValue  { get; set; }
    [JsonProperty("EncoderType")] public string EncoderType  { get; set; }
    [JsonProperty("Frequency")] public int Frequency  { get; set; }
}