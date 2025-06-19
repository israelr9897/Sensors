namespace Sensors.models
{
    internal class SquadLeader : Agent
    {
        internal SquadLeader(int id, string name, List<Sensor> sensorsList) : base(id, name, "SquadLeader", sensorsList) { }

        internal override void Attack()
        {
            if (Game.CounterAttack % 5 == 0)
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
}