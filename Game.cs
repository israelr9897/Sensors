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
        internal static List<Agent> PlayerAgenets = new List<Agent>();


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
            bool IsExit = false;
            while (!IsExit)
            {
                CreateIranAgent();
                System.Console.WriteLine("\n-------- Welcome --------\n");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                System.Console.WriteLine($"-------- Level {Level} --------\n");
                Console.ForegroundColor = ConsoleColor.White;
                Agent.PrintDataAgent(IranAgent);
                System.Console.WriteLine("Waiting for you in the interrogation room.\n");
                ReasetFilds();
                CounterToStepes = 0;
                ManagerGame();
            }
        }
        private bool BasicGame()
        {
            CounterAttack++;
            CounterToStepes++;
            string choice = InputAndCheckChoice();
            PlayerSensors.Add(FactorySensors.CreateInstans(choice));
            ChecksIfSensorExists();
            NumAttempts = SumAllSensorIsExists();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"You were right - {NumAttempts}/{NumOfSensors}");
            Console.ForegroundColor = ConsoleColor.White;
            if (NumAttempts == NumOfSensors)
            {
                return true;
            }
            System.Console.WriteLine("\nYou were unable to pair the correct sensors, please try again.");
            return false;
        }

        private void ManagerGame()
        {
            while (true)
            {
                bool IsWin = BasicGame();
                if (IsWin)
                {
                    PrintWin();
                    break;
                }
                if (CounterToStepes % 10 == 0)
                {
                    PrintTenTries();
                    ReasetFilds();
                }
                if (CounterAttack == 3)
                {
                    IranAgent.Attack();
                    CounterAttack = 0;
                }
            }
            Level++;
        }
        private void ReasetFilds()
        {
            NumAttempts = 0;
            // CounterToStepes = 0;
            CounterAttack = 0;
            PlayerSensors.Clear();
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                sensor.IsActive = false;
            }
        }


        private static void PrintWin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nYou won!!! You managed to find all the correct sensors\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void PrintTenTries()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nYou won!!! You managed to find all the correct sensors\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void CreateIranAgent()
        {
            switch (Level)
            {
                case 1:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("Junior");
                    NumOfSensors = IranAgent.GetSensitiveSensors().Count;
                    break;
                case 2:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("SquadLeader");
                    NumOfSensors = IranAgent.GetSensitiveSensors().Count;
                    break;
                case 3:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("SeniorCommander");
                    NumOfSensors = IranAgent.GetSensitiveSensors().Count;
                    break;
            }
            PlayerAgenets.Add(IranAgent);
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
        private void ChecksIfSensorExists()
        {
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                if (sensor.Active())
                {
                    if (Sensor.counter == 3)
                    {
                        Sensor.counter = 0;
                        foreach (var senso in IranAgent.GetSensitiveSensors())
                        {
                            if (senso.IsActive && sensor.Type == "Pulse")
                            {
                                senso.IsActive = false;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine("You guessed the sensor pulse three times.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
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