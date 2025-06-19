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
                    if (sensor.Key == this.Type.ToLower())
                    {
                        for (int i = 0; i < sensor.Value.Count; i++)
                        {
                            if (!sensor.Value[i])
                            {
                                sensor.Value[i] = true;
                                this.IsActive = true;
                                RevealsLevelAndOneSensor();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void RevealsLevelAndOneSensor()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"\nThe level of the Iranian agent playing against you is -- {Game.IranAgent.GetRankForAgent()} --\n");
            Random random = new Random();
            int len = Game.IranAgent.GetSensitiveSensors().Count;
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"A sensor that the Iranian agent is weak to --- {Game.IranAgent.GetSensitiveSensors()[random.Next(len)].Type} ---");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}