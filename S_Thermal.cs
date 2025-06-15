namespace Sensors.models
{
    internal class S_Thermal : Sensor
    {
        bool Check = false;
        internal void S_ThermalConsole()
        {
            System.Console.WriteLine("Thermal");
        }
        internal override bool Active(Agent agant)
        {
            Check = agant._sensorsList.Contains("Thermal");
            if (Check)
            {
                
                agant._sensorsList[agant._sensorsList.IndexOf("Thermal")] = null;
            }
            return Check;
        }
    }
}