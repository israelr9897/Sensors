namespace Sensors.models
{
    internal class Magnetic : Sensor
    {
        internal Magnetic() : base("Magnetic") { }
        internal override bool Active()
        {
            if (!IsActive)
            {
                foreach (var sensor in Game.PlayerSensors)
                {
                    if ((sensor.Type == this.Type) && (!sensor.IsActive))
                    {
                        sensor.IsActive = true;
                        this.IsActive = true;
                        CounterattackCancellation();
                        return true;
                    }
                }
            }
            return false;
        }
        private void CounterattackCancellation()
        {
            Game.CounterAttack -= 2;
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nTwo counterattacks were foiled.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}