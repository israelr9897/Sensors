namespace Sensors.models
{
    internal class Factory
    {
        private static List<string> OpetionsSensors = new List<string> { "Audio", "Thermal", "Pulse", "Motion", "Magnetic" };
        private static List<Sensor> sen = new List<Sensor> { new S_Audio(), new S_Thermal() };
        // private static List<Agent> Agents = new List<Agent>();

        internal static List<Sensor> FactoryList()
        {
            Random random = new Random();
            int Len = sen.Count;
            List<Sensor> Sensors = new List<Sensor> { sen[random.Next(0,1)], sen[random.Next(1,2)] };
            foreach (var item in Sensors)
            {
                System.Console.WriteLine(item);
            }
            // List<Sensor> Sensors = new List<Sensor> { sen[0], sen[0] };
            return Sensors;

        }
        internal static Agent FactoryAgent()
        {
            return new JuniorAgent();
        }
    }
}