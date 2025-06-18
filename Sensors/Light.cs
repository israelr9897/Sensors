namespace Sensors.models
{
    internal class Light : Sensor
    {
        internal Light() : base("Light") { }
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
                        RevealsLevelAndOneSensor();
                        return true;
                    }
                }
            }
            return false;
        }
        private void RevealsLevelAndOneSensor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"\nThe level of the Iranian agent playing against you is -- {Game.IranAgent.GetRankForAgent()} --\n");
            foreach (var sensor in Game.IranAgent.GetSensitiveSensors())
            {
                if (!sensor.IsActive)
                {
                    System.Console.WriteLine($"And a sensor that the agent is sensitive to is -- {sensor.Type} --\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    }
}