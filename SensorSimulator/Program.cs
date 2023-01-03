using System;
using SensorSimulator.Model;
using SensorSimulator.Controller;
using Timer = System.Timers.Timer;

var rnd = new Random();
var timers = new List<Timer>();
Sensor[] sensorsArray;

string GetQuality(int value, int minValue, int maxValue)
{
    string result;

    var totalValue = maxValue - minValue;
    
    value -= minValue;
    if (value < 0) value *= -1;
    
    var percentage = (float)value / totalValue;

    switch (percentage)
    {
        case <= 0.10f:
        case >= 0.90f:
            result = "Alarm";
            break;
        case <= 0.25f:
        case >= 0.75f:
            result = "Warning";
            break;
        default:
            result = "Normal";
            break;
    }
    
    return result;
}

void OnTimedEvent(Sensor sensor)
{
    var value = rnd.Next(sensor.MinValue, sensor.MaxValue);
    var quality = GetQuality(value, sensor.MinValue, sensor.MaxValue);
    Console.WriteLine($"$FIX, {sensor.ID}, {sensor.Type}, {value}, {quality}*");
}

//read JSON path
while (true)
{
    try
    {
        Console.Write("Pass JSON path: ");
        var jsonPath = Console.ReadLine();
        sensorsArray = JsonController.ReadFrom(jsonPath).SensorsArray;
        break;
    }
    catch
    {
        Console.WriteLine("Error on JSON reading, try again.");
    }
}

foreach (var sensor in sensorsArray)
{
    var tmpTimer = new Timer(); 
    tmpTimer.Elapsed += delegate { OnTimedEvent(sensor); };
    tmpTimer.Interval = 1000f / sensor.Frequency;
    tmpTimer.Enabled = true;
    timers.Add(tmpTimer);
}

foreach (var timer in timers)
{
    timer.Start();
}

Console.ReadLine();


foreach (var timer in timers)
{
    timer.Stop();
    timer.Dispose();
}