namespace Sensors.models
{
    internal class SquadLeader : Agent
    {
        internal SquadLeader(string name, List<Sensor> sensorsList) : base(name, "SquadLeader", sensorsList) { }

        internal override void Attack()
        {
            foreach (var sensor in GetSensitiveSensors())
            {
                if (sensor.IsActive)
                {
                    sensor.IsActive = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("\n⚠️⚠️ An attack is being carried out against ⚠️⚠️\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    } 
}