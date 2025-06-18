namespace Sensors.models
{
    internal class Player
    {
        internal string Name;
        internal string CodePlayer;
        internal int Level = 1;
        public List<Sensor> PlayerSensors = new List<Sensor>();
        internal Player(string name, string codePlayer, int level)
        {
            Name = name;
            CodePlayer = codePlayer;
            Level = level;
        }
    }
}