using System.Timers;
using SensorSimulator.Model;
using SensorSimulator.Controller;

Console.Write("Pass json path: ");//Users/admin/RiderProjects/SensorSimulator/SensorSimulator/Data/sensorConfig.json
string jsonPath = Console.ReadLine();
var sensorsList = JsonController.ReadFrom(jsonPath);

if (sensorsList != null)
{
    var timers = new List<System.Timers.Timer>();
    foreach (var sensor in sensorsList)
    {
        var tmpTimer = new System.Timers.Timer(); 
        tmpTimer.Elapsed += delegate { OnTimedEvent(sensor); };
        tmpTimer.Interval = 1000f / sensor.Frequency;
        tmpTimer.Enabled = true;
        timers.Add(tmpTimer);
    }
}
else
{
    Console.WriteLine("Init error!");
}

void OnTimedEvent(Sensor sensor)
{
    Console.WriteLine($"$FIX, {sensor.ID}, {sensor.Type}, {sensor.Frequency}");
}

