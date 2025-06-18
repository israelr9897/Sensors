namespace Sensors.models
{
    internal class Signal : Sensor
    {
        internal Signal() : base("Signal") { }
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
                        RevealsLevel();
                        return true;
                    }
                }
            }
            return false;
        }
        private void RevealsLevel()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"\nThe level of the Iranian agent playing against you is -- {Game.IranAgent.GetRankForAgent()} --\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}