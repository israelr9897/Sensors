namespace Sensors.models
{
    internal class Agent
    {
        internal string _Name;
        internal string _Rank;
        private List<Sensor> _SensitiveSensors { get; }
        public List<string> _PlayerSensors = new List<string>();
        internal Agent(string name, string rank, List<Sensor> senList)
        {
            _SensitiveSensors = senList;
            _Name = name;
            _Rank = rank;
        }
        internal List<Sensor> GetSensorsList()
        {
            return _SensitiveSensors;
        }
        internal static void PrintDataAgent(Agent agent)
        {
            System.Console.WriteLine($"Name: {agent._Name}");
            System.Console.WriteLine($"Rank: {agent._Rank}");
        }
    }
}