namespace Sensors.models
{
    internal class Pulse : Sensor
    {
        internal Pulse() : base("Pulse")
        {
        }
        internal override bool Active(Agent agent)
        {
            List<Sensor> PlayerSensors = agent._PlayerSensors;
            this.Counter += 1;
            if (this.Counter == 3)
            {
                Game.NumAttempts--;
            }

            for (int i = 0; i < PlayerSensors.Count; i++)
            {
                if ((PlayerSensors[i].Type == this.Type) && !(this.situation ))
                {
                    PlayerSensors[i].situation = true;
                    this.situation = true;
                    return true;
                }
            }
            // if (this.Type == type && !this.situation)
            // {
            //     this.situation = true;
            //     return true;
            // }
            return false;
        }
    }
}