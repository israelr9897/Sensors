namespace Sensors.models
{
    internal class Audio : Sensor
    {
        internal Audio() : base("Audio"){}
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
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        
        }
    }
}