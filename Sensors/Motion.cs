namespace Sensors.models
{
    internal class Motion : Sensor
    {
        internal Motion() : base("Motion"){}
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