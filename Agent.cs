namespace Sensors.models
{
    internal class Agent
    {
        private List<string> _sensorsList { get; set; }
        internal Agent(List<string> sensorsList)
        {
            _sensorsList = sensorsList;
        }
        internal List<string> GetSensorsList()
        {
            return _sensorsList;
        }
    }
}