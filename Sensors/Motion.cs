namespace Sensors.models
{
    internal class Motion : Sensor
    {
        internal Motion() : base("Motion"){}
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