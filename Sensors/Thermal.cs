namespace Sensors.models
{
    internal class Thermal : Sensor
    {
        internal Thermal() : base("Thermal") { }
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
                                this.IsActive = true;
                                OneSensorDetects();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void OneSensorDetects()
        {
            Random random = new Random();
            int len = ManagerGame.IranAgent.GetSensitiveSensors().Count;
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine($"A sensor that the Iranian agent is weak to --- {ManagerGame.IranAgent.GetSensitiveSensors()[random.Next(len)].Type} ---");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}