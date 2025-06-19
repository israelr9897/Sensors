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
                    if (sensor.Key == this.Type.ToLower())
                    {
                        for (int i = 0; i < sensor.Value.Count; i++)
                        {
                            if (!sensor.Value[i])
                            {
                                sensor.Value[i] = true;
                                this.IsActive = true;
                                this.IsActive = true;
                                RevealsRank();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void RevealsRank()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"\nThe level of the Iranian agent playing against you is -- {Game.IranAgent.GetRankForAgent()} --\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}