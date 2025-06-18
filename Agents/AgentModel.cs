namespace Sensors.models
{
    internal class Agent
    {
        internal string Name;
        private string _Rank{ get; }
        private List<Sensor> _SensitiveSensors { get; }
        internal Agent(string name, string rank, List<Sensor> senList)
        {
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