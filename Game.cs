using System.Numerics;

namespace Sensors.models
{
    internal class Game
    {
        private static Game _instansce;
        private static int NumOfSensors;
        private static int NumAttempts = 0;
        private int CounterToStepes = 0;
        private int CounterAttack = 0;
        private int Level = 1;
        private Agent IranAgent;


        internal static List<Sensor> PlayerSensors = new List<Sensor>();


        private Game()
        {
            FirstLevel();
        }
        public static Game GetInstance()
        {
            if (_instansce == null)
            {
                _instansce = new Game();
            }
            return _instansce;
        }

        private void FirstLevel()
        {
            StGame();
            bool IsWin = false;
            while (!IsWin)
            {
                if (CounterToStepes >= 10)
                {
                    ReasetFilds();
                }
                if (BasicGame())
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine("\nYou won!!! You managed to find all the correct sensors\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    IsWin = true;
                }
            }
            SecondLevel();
        }
        private void SecondLevel()
        {
            Level = 2;
            ReasetFilds();
            StGame();
            bool IsWin = false;
            while (!IsWin)
            {
                if (CounterAttack == 3)
                {
                    IranAgent.Attack();
                    CounterAttack = 0;
                }
                // foreach (var sensor in IranAgent.GetSensitiveSensors())
                // {
                //     System.Console.WriteLine(sensor.Type + " - " + sensor.IsActive);
                // }
                if (NumAttempts >= 10)
                    {
                        ReasetFilds();
                    }
                if (BasicGame())
                {
                    IsWin = true;
                }
            }
        }

                // while (NumAttempts != NumOfSensors && !IsContinue)
                // {
                //     NumAttempts = 0;
                //     for (int i = 0; i < 10; i++)
                //     {
                //         CounterAttack++;
                //         string choice = InputAndCheckChoice();
                //         PlayerSensors.Add(FactorySensors.CreateInstans(choice));
                //         NumAttempts += ChecksIfSensorExists(agent);
                //         // if (agent._Rank == "SquadLeader" && CounterAttack == 3)
                //         // {
                //         //     agent.Attack();
                //         //     CounterAttack = 0;
                //         // }
                //         Console.ForegroundColor = ConsoleColor.Green;
                //         System.Console.WriteLine($"You were right - {NumAttempts}/{NumOfSensors}");
                //         Console.ForegroundColor = ConsoleColor.White;
                //         System.Console.WriteLine(CounterAttack);
                //         if (NumAttempts == NumOfSensors)
                //         {
                //             IsContinue = CheckIsContinue();
                //             break;
                //         }
                //         System.Console.WriteLine("\nYou were unable to pair the correct sensors,");
                //         System.Console.WriteLine($"there are -- {9 - i} -- more attempts left until the previous pairings are reset.\n");
                //     }
                //     PlayerSensors.Clear();
                //     foreach (var sensor in agent.GetSensitiveSensors())
                //     {
                //         sensor.IsActive = false;
                //     }
                // }


        private void ReasetFilds()
        {
            NumAttempts = 0;
            CounterToStepes = 0;
            CounterAttack = 0;
            PlayerSensors.Clear();
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                sensor.IsActive = false;
            }
        }

        private bool BasicGame()
        {
            // while (NumAttempts != NumOfSensors)
            // {
            //     NumAttempts = 0;
            //     for (int i = 0; i < 10; i++)
            //     {
            CounterAttack++;
            CounterToStepes++;
            string choice = InputAndCheckChoice();
            PlayerSensors.Add(FactorySensors.CreateInstans(choice));
            ChecksIfSensorExists();
            // if (agent._Rank == "SquadLeader" && CounterAttack == 3)
            // {
            //     agent.Attack();
            //     CounterAttack = 0;
            // }
            NumAttempts = SumAllSensorIsExists();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"You were right - {NumAttempts}/{NumOfSensors}");
            Console.ForegroundColor = ConsoleColor.White;
            if (NumAttempts == NumOfSensors)
            {
                return true;
            }
            System.Console.WriteLine("\nYou were unable to pair the correct sensors,");
            System.Console.WriteLine($"there are -- {10 - CounterToStepes} -- more attempts left until the previous pairings are reset.\n");
            return false;
        }


        private static void Prin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nYou won!!! You managed to find all the correct sensors\n");
            Console.ForegroundColor = ConsoleColor.White;
        }



        private void StGame()
        {
            if (Level == 1)
            {
                IranAgent = FactoryAgents.FactoryJuniorAgent("Junior");
                NumOfSensors = IranAgent.GetSensitiveSensors().Count;
            }
            else if (Level == 2)
            {
                IranAgent = FactoryAgents.FactoryJuniorAgent("SquadLeader");
                NumOfSensors = IranAgent.GetSensitiveSensors().Count;
            }
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine($"-------- Level {Level} --------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Agent.PrintDataAgent(IranAgent);
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");
        }

        private int SumAllSensorIsExists()
        {
            int total = 0;
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                if (sensor.IsActive)
                {
                    total++;
                }
            }
            return total;
        }
        private int ChecksIfSensorExists()
        {
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                if (sensor.Active())
                {
                    return Sensor.counter != 3 ? 1 : Sensor.counter = 0;
                }
            }
            return 0;
        }
        
        private string InputAndCheckChoice()
        {
            System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
            string choice = Console.ReadLine().ToLower();
            bool check = FactorySensors.OpetionsSensors.Contains(choice);
            while (!check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("--- There is no such sensor, please insert one from the existing sensors. ---\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic");
                choice = Console.ReadLine();
                check = FactorySensors.OpetionsSensors.Contains(choice.ToLower());
            }
            return choice;
        }
    }
}