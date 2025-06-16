using System.Numerics;

namespace Sensors.models
{
    public class Game
    {
        public static int NumAttempts = 0;
        static internal void StGame()
        {
            Agent agent = FactoryAgents.FactoryJuniorAgent("Muhamad");
            int len = agent.GetSensorsList().Count;
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Agent.PrintDataAgent(agent);
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");

            while (NumAttempts != len)
            {
                NumAttempts = 0;
                for (int i = 0; i < 10; i++)
                {
                    System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
                    string choice = Console.ReadLine();
                    agent._PlayerSensors.Add(choice);
                    NumAttempts += CheckSensor(agent, choice);
                    System.Console.WriteLine($"You were right - {NumAttempts}/{len}");
                    if (NumAttempts == len)
                    {
                        break;
                    }
                    System.Console.WriteLine("\nYou were unable to pair the correct sensors,");
                    System.Console.WriteLine($"there are -- {9 - i} -- more attempts left until the previous pairings are reset.");
                }
                agent._PlayerSensors.Clear();
                foreach (var sensor in agent.GetSensorsList())
                {
                    sensor.situation = false;
                }
            }
        }
        internal static int CheckSensor(Agent agent, string type)
        {
            int total = 0;
            foreach (var sensor in agent.GetSensorsList())
            {
                if (sensor.Active(agent, type))
                {
                    total += 1;
                    break;
                }
            }
            return total;
        }
    }
}