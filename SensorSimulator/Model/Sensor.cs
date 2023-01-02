namespace SensorSimulator.Model;

public class Sensor
{
    public Sensor(int id, string type, int minValue, int maxValue, string encoderType, int frequency)
    {
        ID = id;
        Type = type;
        MinValue = minValue;
        MaxValue = maxValue;
        EncoderType = encoderType;
        Frequency = frequency;
    }
    public int ID { get; set; }
    public string Type  { get; set; }
    public int MinValue  { get; set; }
    public int MaxValue  { get; set; }
    public string EncoderType  { get; set; }
    public int Frequency  { get; set; }
}