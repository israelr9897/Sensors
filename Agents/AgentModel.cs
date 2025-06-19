namespace Sensors.models
{
    internal class Agent
    {
        internal int ID;
        internal string Name;
        private string _Rank{ get; }
        private List<Sensor> _SensitiveSensors { get; }
        internal Agent(int id, string name, string rank, List<Sensor> senList)
        {
            ID = id;
            _SensitiveSensors = senList;
            Name = name;
            _Rank = rank;
        }
        internal List<Sensor> GetSensitiveSensors()
        {
            return _SensitiveSensors;
        }
        internal string GetRankForAgent()
        {
            return _Rank;
        }
        internal virtual void Attack() { }
    }
}