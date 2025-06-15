namespace Sensors.models
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent a = Factory.FactoryAgent();
            System.Console.WriteLine(a.GetSensorsList()[0]);
        }
    }
}