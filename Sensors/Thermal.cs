namespace Sensors.models
{
    internal class Thermal : Sensor
    {
        internal Thermal() : base("Thermal"){}
        internal override bool Active(Agent agent)
        {
            List<Sensor> PlayerSensors = agent._PlayerSensors;

            for (int i = 0; i < PlayerSensors.Count; i++)
            {
                if ((PlayerSensors[i].Type == this.Type) && !(this.situation ))
                {
                    PlayerSensors[i].situation = true;
                    this.situation = true;
                    return true;
                }
            }
            return false;
        }
    }
}