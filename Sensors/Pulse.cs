namespace Sensors.models
{
    internal class Pulse : Sensor
    {
        internal Pulse() : base("Pulse"){}
        internal override bool Active(Agent agent, string type)
        {
            if (this.Type == type && !this.situation)
            {
                this.situation = true;
                return true;
            }
            return false;
        }
    }
}