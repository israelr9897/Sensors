namespace Sensors.models
{
    internal class OrganizationLeader : Agent
    {
        internal OrganizationLeader(string name, List<Sensor> sensorsList) : base(name, "OrganizationLeader", sensorsList) { }

        internal override void Attack()
        {
            if (Game.CounterAttack == 4)
            {
                foreach (var sensor in GetSensitiveSensors())
                {
                    if (sensor.IsActive)
                    {
                        sensor.IsActive = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine("\n⚠️⚠️ An attack is being carried out against ⚠️⚠️\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Game.CounterAttack = 0;
                    }
                }
            }
        }
    } 
}