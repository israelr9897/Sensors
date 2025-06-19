namespace Sensors.models
{
    internal class FactorySensors
    {
        internal static string[] OpetionsSensors =  { "audio", "thermal", "pulse", "motion", "magnetic", "signal", "light" };
        internal static List<Sensor> FactoryList(int num)
        {
            List<Sensor> Sensors = new List<Sensor> ();
            for (int i = 0; i < num; i++)
            {
                int Len = OpetionsSensors.Length;
                Random random = new Random();
                string type = OpetionsSensors[random.Next(Len)];
                Sensors.Add(CreateInstans(type));
            }
            foreach (var item in Sensors)
            {
                System.Console.WriteLine(item);
            }
            return Sensors;

        }
        internal static Sensor CreateInstans(string type)
        {
            switch (type.ToLower())
            {
                case "audio":
                    return new Audio();

                case "thermal":
                    return new Thermal();

                case "pulse":
                    return new Pulse();

                case "motion":
                    return new Motion();

                case "magnetic":
                    return new Magnetic();

                case "signal":
                    return new Signal();
                case "light":
                    return new Light();
            }
            return null;
        }
    }
}