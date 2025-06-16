namespace Sensors.models
{
    internal abstract class Sensor
    {
        internal string Type;
        internal bool situation = false;
        internal int Counter = 0;

        internal Sensor(string type)
        {
            Type = type;
        }
        internal abstract bool Active(Agent agent, string type);
    }
}