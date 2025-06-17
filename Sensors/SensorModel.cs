namespace Sensors.models
{
    internal abstract class Sensor
    {
        internal string Type;
        internal bool IsActive = false;
        internal static int counter = 0;

        internal Sensor(string type)
        {
            Type = type;
        }
        internal abstract bool Active();
    }
}