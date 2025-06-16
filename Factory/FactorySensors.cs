namespace Sensors.models
{
    internal class FactorySensors
    {
        private static string[] OpetionsSensors =  { "Audio", "Thermal", "Pulse", "Motion", "Magnetic" };
        internal static List<Sensor> FactoryList(int num)
        {
            // List<Sensor> Sensors = new List<Sensor> { new Pulse(), new Pulse() };
            List<Sensor> Sensors = new List<Sensor> ();
            for (int i = 0; i < num; i++)
            {
                Sensors.Add(CreateInstans());
            }
            foreach (var item in Sensors)
            {
                System.Console.WriteLine(item);
            }
            return Sensors;

        }
        internal static Sensor CreateInstans()
        {
            int Len = OpetionsSensors.Length;
            Random random = new Random();
            string type = OpetionsSensors[random.Next(Len)];
            switch (type)
            {
                case "Audio":
                    return new Audio();

                case "Thermal":
                    return new Thermal();

                case "Pulse":
                    return new Pulse();

                case "Motion":
                    return new Motion();

                case "Magnetic":
                    return new Magnetic();
            }
            return null;
        }
    }
}