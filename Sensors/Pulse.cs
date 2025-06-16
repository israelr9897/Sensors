namespace Sensors.models
{
    internal class Pulse : Sensor
    {
        // internal static int Counter = 0;
        internal Pulse() : base("Pulse")
        {
        }
        internal override bool Active(Agent agent)
        {
            List<Sensor> PlayerSensors = agent._PlayerSensors;
            for (int i = 0; i < PlayerSensors.Count; i++)
            {
                if ((PlayerSensors[i].Type == this.Type) && (!this.situation) && (!PlayerSensors[i].situation))
                {
                    agent._PlayerSensors[i].situation = true;
                    this.situation = true;
                    return true;
                }
            }
            return false;
        }
    }
}