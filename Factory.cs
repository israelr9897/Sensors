namespace Sensors.models
{
    internal class Factory
    {
        private static List<string> OpetionsSensors = new List<string> { "Audio", "Thermal", "Pulse", "Motion", "Magnetic" };
        // private static List<Agent> Agents = new List<Agent>();

        internal static List<string> FactoryList()
        {
            Random random = new Random();
            int Len = OpetionsSensors.Count;
            List<string> Sensors = new List<string> { OpetionsSensors[random.Next(Len)], OpetionsSensors[random.Next(Len)] };
            return Sensors;

        }
        internal static Agent FactoryAgent()
        {
            return new JuniorAgent();
        }
    }
}