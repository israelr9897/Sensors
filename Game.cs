using System.Numerics;

namespace Sensors.models
{
    internal class Game
    {
        public static int NumAttempts = 0;
        private static Game _instansce;
        private int CounterAttack = 0;
        private int CounterPulse = 0;
        internal static List<Sensor> _PlayerSensors = new List<Sensor>();


        private Game()
        {
            StGame();
        }
        public static Game GetInstance()
        {
            if (_instansce == null)
            {
                _instansce = new Game();
            }
            return _instansce;
        }

        private void StGame()
        {
            Agent agent = FactoryAgents.FactoryJuniorAgent("Muhamad");
            int len = agent.GetSensitiveSensors().Count;
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Agent.PrintDataAgent(agent);
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");

            while (NumAttempts != len)
            {
                NumAttempts = 0;
                string choice = "";
                for (int i = 0; i < 10; i++)
                {
                    CounterAttack++;
                    do
                    {
                        System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
                        choice = Console.ReadLine();
                    } while (!CheckChoice(choice));    
                    _PlayerSensors.Add(FactorySensors.CreateInstans(choice));
                    NumAttempts += ChecksIfSensorExists(agent);
                    if (agent._Rank == "SquadLeader" && CounterAttack == 3)
                    {
                        agent.Attack();
                        CounterAttack = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"You were right - {NumAttempts}/{len}");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine(CounterAttack);
                    if (NumAttempts == len)
                    {
                        break;
                    }
                    System.Console.WriteLine("\nYou were unable to pair the correct sensors,");
                    System.Console.WriteLine($"there are -- {9 - i} -- more attempts left until the previous pairings are reset.\n");
                }
                _PlayerSensors.Clear();
                foreach (var sensor in agent.GetSensitiveSensors())
                {
                    sensor.IsActive = false;
                }
            }
        }
        internal static int ChecksIfSensorExists (Agent agent)
        {
            foreach (var sensor in agent.GetSensitiveSensors())
            {
                if (sensor.Active())
                {
                    return Sensor.counter != 3? 1:Sensor.counter = 0;
                }
            }
            return 0;
        }
        internal static bool CheckChoice(string choice)
        {
            bool check = FactorySensors.OpetionsSensors.Contains(choice.ToLower());
            if (!check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("--- There is no such sensor, please insert one from the existing sensors. ---\n");
                Console.ForegroundColor = ConsoleColor.White;
            }return check;
        }
    }
}