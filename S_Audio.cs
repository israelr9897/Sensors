namespace Sensors.models
{
    internal class S_Audio : Sensor
    {
        bool Check = false;
        internal void S_AudioConsole()
        {
            System.Console.WriteLine("Audio");
        }
        internal override bool Active(Agent agant)
        {
            Check = agant._sensorsList.Contains("Audio");
            if (Check)
            {
                
            agant._sensorsList[agant._sensorsList.IndexOf("Audio")] = null;
            }
            return Check;
        }
    }
}