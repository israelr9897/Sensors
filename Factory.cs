namespace Sensors.models
{
    internal class Factory
    {
        private static List<string> OpetionsSensors = new List<string> { "Audio", "Thermal", "Pulse", "Motion", "Magnetic" };
        internal static List<Sensor> FactoryList()
        {
            List<Sensor> Sensors = new List<Sensor> { CreateInstans(), CreateInstans() };
            foreach (var item in Sensors)
            {
                System.Console.WriteLine(item);
            }
            return Sensors;

        }
        internal static Agent FactoryJuniorAgent(string name)
        {
            return new JuniorAgent(name);
        }
        internal static Sensor CreateInstans()
        {
            int Len = OpetionsSensors.Count;
            Random random = new Random();
            string type = OpetionsSensors[random.Next(Len)];
            switch (type)
            {
                case "Audio":
                    return new Audio();

                case "Thermal":
                    return new Thermal();
                    
                case "Pulse":
                    return new Thermal();

                case "Motion":
                    return new Thermal();

                case "Magnetic":
                    return new Thermal();
            }
            return null;
        }
    }
}