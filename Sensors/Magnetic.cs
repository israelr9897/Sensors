namespace Sensors.models
{
    internal class Magnetic : Sensor
    {
        internal Magnetic() : base("Magnetic") { }
        internal override bool Active()
        {
            if (!IsActive)
            {
                foreach (var sensor in ManagerGame.PlayerSensors)
                {
                    if (sensor.Key == this.Type.ToLower())
                    {
                        for (int i = 0; i < sensor.Value.Count; i++)
                        {
                            if (!sensor.Value[i])
                            {
                                sensor.Value[i] = true;
                                this.IsActive = true;
                                CounterattackCancellation();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void CounterattackCancellation()
        {
            ManagerGame.CounterAttack -= 2;
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nTwo counterattacks were foiled.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}