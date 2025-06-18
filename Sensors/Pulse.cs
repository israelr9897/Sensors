namespace Sensors.models
{
    internal class Pulse : Sensor
    {
        internal static int Counter = 0;
        internal Pulse() : base("Pulse")
        {
        }
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
                        Counter++;
                        if (Counter == 3)
                        {
                            Counter = 0;
                            TurnsOffOneSensor();
                        }
                        return true;
                    }
                }
            }   
            return false;
        }
        private void TurnsOffOneSensor()
        {
            foreach (var sensor in Game.IranAgent.GetSensitiveSensors())
            {
                if (sensor.IsActive && sensor.Type == "Pulse")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("You guessed the sensor -- Pulse -- three times.");
                    Console.ForegroundColor = ConsoleColor.White;
                    sensor.IsActive = false;
                    break;
                }
            }
        }
    }
}