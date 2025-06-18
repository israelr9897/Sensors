namespace Sensors.models
{
    internal class Motion : Sensor
    {
        internal Motion() : base("Motion"){}
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
                        return true;
                    }
                }
            }
            return false;
        }
    }
}