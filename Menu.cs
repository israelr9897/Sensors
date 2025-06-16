using System.Numerics;

namespace Sensors.models
{
    public class Menu
    {
        static internal void StMenu()
        {
            Agent agent = Factory.FactoryJuniorAgent("Muhamad");
            int len = agent.GetSensorsList().Count;
            int total = 0;
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Agent.PrintDataAgent(agent);
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");

            while (total != agent.GetSensorsList().Count)
            {
                total = 0;
                for (int i = 0; i < agent.GetSensorsList().Count; i++)
                {
                    System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
                    string choice = Console.ReadLine();
                    agent._sensorsList.Add(choice);
                    total += CheckSensor(agent, choice);
                    System.Console.WriteLine($"You were right - {total}/{len}");
                }
                if (total != 2)
                {
                    agent._sensorsList.Clear();
                    foreach (var sensor in agent.GetSensorsList())
                    {
                        sensor.situation = false;    
                    }
                    System.Console.WriteLine("\nYou did not find the correct sensors, please enter again.");
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
        // internal static int CheckAllSEnsors(Agent agent)
        // {
        //     int total = 0;
        //     foreach (var sensor in agent.GetSensorsList())
        //     {
        //         System.Console.WriteLine(sensor.situation);
        //         if (sensor.situation)
        //         {
        //             total += 1;
        //         }
        //     }
                
        //     return total;
        // }
        

    }
}