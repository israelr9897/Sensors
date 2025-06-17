namespace Sensors.models
{
    internal class Thermal : Sensor
    {
        internal Thermal() : base("Thermal"){}
        internal override bool Active()
        {
            foreach(var sensor in Game._PlayerSensors)
            {
                if ((sensor.Type == this.Type) && (!this.IsActive) && (!sensor.IsActive))
                {
                    sensor.IsActive = true;
                    this.IsActive = true;
                    return true;
                }
            }
            return false;
        }
    }
}