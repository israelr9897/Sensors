namespace Sensors.models
{
    internal class Thermal : Sensor
    {
        internal Thermal() : base("Thermal"){}
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