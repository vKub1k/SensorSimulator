using System;
using SensorSimulator.Model;
using SensorSimulator.Controller;
using Timer = System.Timers.Timer;
using SensorSimulator.Converters;

var rnd = new Random();
var timers = new List<Timer>();
Sensor[] sensorsArray;

//method to be called from timer with sensor instance.
void OnTimedEvent(Sensor sensor)
{
    var value = rnd.Next(sensor.MinValue, sensor.MaxValue);
    var quality = QualityConverter.GetQuality(value, sensor.MinValue, sensor.MaxValue);
    Console.WriteLine($"$FIX, {sensor.ID}, {sensor.Type}, {value}, {quality}*");
}

//read JSON file path.
while (true)
{
    try
    {
        Console.Write("Pass JSON full path: ");
        var jsonPath = Console.ReadLine();
        sensorsArray = JsonController.ReadFrom(jsonPath).SensorsArray;
        break;
    }
    catch
    {
        Console.WriteLine("Error on JSON reading, try again.");
    }
}

//create new timers with sensor instance.
foreach (var sensor in sensorsArray)
{
    var tmpTimer = new Timer(); 
    tmpTimer.Elapsed += delegate { OnTimedEvent(sensor); };
    tmpTimer.Interval = 1000f / sensor.Frequency;
    tmpTimer.Enabled = true;
    timers.Add(tmpTimer);
}

//start all timers.
foreach (var timer in timers)
{
    timer.Start();
}

//pause program to see how timers works.
Console.ReadLine();

//stop timers and clear memory.
foreach (var timer in timers)
{
    timer.Stop();
    timer.Dispose();
}