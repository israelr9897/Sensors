namespace Sensors.models
{
    internal class Magnetic : Sensor
    {
        internal Magnetic() : base("Magnetic"){}
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