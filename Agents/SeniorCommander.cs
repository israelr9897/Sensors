namespace Sensors.models
{
    internal class SeniorCommander : Agent
    {
        internal SeniorCommander(string name, List<Sensor> sensorsList) : base(name, "SeniorCommander", sensorsList) { }

        internal override void Attack()
        {
            int count = 0;
            foreach (var sensor in GetSensitiveSensors())
            {
                if (sensor.IsActive)
                {
                    count++;
                    sensor.IsActive = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("\n⚠️⚠️ An attack is being carried out against ⚠️⚠️\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (count == 2)
                    {
                        break;
                    }
                }
            }
        }
    } 
}