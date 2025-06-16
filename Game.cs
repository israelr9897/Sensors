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
                int CountPulse = 0;
                string choice = "";
                for (int i = 0; i < 10; i++)
                {
                    do
                    {
                        System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
                        choice = Console.ReadLine();
                    } while (!CheckChoice(choice));
                    if (choice == "Pulse")
                    {
                        CountPulse += 1;
                        if (CountPulse == 3)
                        {
                            NumAttempts--;
                            CountPulse = 0;
                        }
                    }
                    agent._PlayerSensors.Add(FactorySensors.CreateInstans(choice));
                    NumAttempts += CheckSensor(agent);
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"You were right - {NumAttempts}/{len}");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (NumAttempts == len)
                    {
                        break;
                    }
                    System.Console.WriteLine("\nYou were unable to pair the correct sensors,");
                    System.Console.WriteLine($"there are -- {9 - i} -- more attempts left until the previous pairings are reset.\n");
                }
                agent._PlayerSensors.Clear();
                foreach (var sensor in agent.GetSensorsList())
                {
                    sensor.situation = false;
                }
            }
        }
        internal static int CheckSensor(Agent agent)
        {
            int total = 0;
            foreach (var sensor in agent.GetSensorsList())
            {
                if (sensor.Active(agent))
                {
                    total += 1;
                    break;
                }
            }
            return total;
        }
        internal static bool CheckChoice(string choice)
        {
            bool check = FactorySensors.OpetionsSensors.Contains(choice);
            if (!check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("--- There is no such sensor, please insert one from the existing sensors. ---\n");
                Console.ForegroundColor = ConsoleColor.White;
            }return check;
        }
    }
}