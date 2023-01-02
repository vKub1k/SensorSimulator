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
    public int ID = 2;
    public string Type = "position";
    public int MinValue = -10000;
    public int MaxValue = 10000;
    public string EncoderType = "fixed";
    public int Frequency = 1;
}