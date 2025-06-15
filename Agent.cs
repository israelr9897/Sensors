namespace Sensors.models
{
    internal class Agent
    {
        private List<Sensor> _sensorsToAgant { get; set; }
        public List<string> _sensorsList = new List<string>();
        internal Agent(List<Sensor> senList)
        {
            _sensorsToAgant = senList;
        }
        internal List<Sensor> GetSensorsList()
        {
            return _sensorsToAgant;
        }
    }
}