namespace Sensors.models
{
    internal class Pulse : Sensor
    {
        // internal static int Counter = 0;
        internal Pulse() : base("Pulse")
        {
        }
        internal override bool Active()
        {
            if (!IsActive)
            {
                Sensor.counter++;
                foreach (var sensor in Game._PlayerSensors)
                {
                    if ((sensor.Type == this.Type) && (!sensor.IsActive) && counter != 3)
                    {
                        sensor.IsActive = true;
                        this.IsActive = true;
                        return true;
                    }
                }
            }
            return counter != 3? false:true;
        }
    }
}