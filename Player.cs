namespace Sensors.models
{
    internal class Player
    {
        internal string Name;
        internal int Level = 0;
        public List<Sensor> PlayerSensors = new List<Sensor>();
        internal Player(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}