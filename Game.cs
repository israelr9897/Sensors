using System.Numerics;

namespace Sensors.models
{
    internal class Game
    {
        private static Game _instansce;
        private static int NumOfSensors;
        private static int NumAttempts = 0;
        private int CounterToStepes = 0;
        internal static int CounterAttack = 0;
        internal static Agent IranAgent;
        internal static Player player;
        private int Level;


        internal static List<Sensor> PlayerSensors = new List<Sensor>();
        internal static List<Agent> AgenetsToGame = new List<Agent>();


        private Game()
        {
            MySqlConnect conn = new MySqlConnect();
            conn.connect();
            new DalPeople(conn);
            CheckAndInputNewPlayer();
            StartGame();     
            GameManager();
        }
        public static Game GetInstance()
        {
            if (_instansce == null)
            {
                _instansce = new Game();
            }
            return _instansce;
        }
        private void CheckAndInputNewPlayer()
        {
            System.Console.WriteLine("What your  - code player - ? ");
            string codePlayer = Console.ReadLine();
            if (!DalPeople.ChecksIfPlayerExistsByCodePlayer(codePlayer))
            {
                System.Console.WriteLine("What your  - name - ? ");
                string name = Console.ReadLine();
                DalPeople.AddPlayer(name, DalPeople.CreatCodePlayer(name));
            }
            player = DalPeople.FindPlayerByCP(codePlayer);
            Level = player.Level;
        }
        private void StartGame()
        {
            CreateIranAgent();
            ReasetFilds();
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine($"-------- Level {Level} --------\n");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"Name: {IranAgent.Name}");
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");
            CounterToStepes = 0;
        }
        private void GameManager()
        {
            while (true)
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
                IranAgent.Attack();
                System.Console.WriteLine(SumAllSensorIsExists()+ "  total");
                if (SumAllSensorIsExists() == NumOfSensors)
                {
                    PrintWin();
                    Level++;
                    if (Level == 5)
                    {
                        break;
                    }
                    StartGame();
                }
                else
                {
                    System.Console.WriteLine("\nYou were unable to pair the correct sensors, please try again.");
                    IsTenTries();
                }
            }
        }
        private void ReasetFilds()
        {
            NumAttempts = 0;
            Pulse.Counter = 0;
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
        private void IsTenTries()
        {
            if (CounterToStepes % 10 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine("\nIt's been 10 tries !!! you'll have to start all over again.\n");
                Console.ForegroundColor = ConsoleColor.White;
                ReasetFilds();
            }
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
                case 4:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("OrganizationLeader");
                    NumOfSensors = IranAgent.GetSensitiveSensors().Count;
                    break;
            }
            AgenetsToGame.Add(IranAgent);
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
                    break;
                }
            }
        }
        
        private string InputAndCheckChoice()
        {
            System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic / Signal / Light");
            string choice = Console.ReadLine().ToLower();
            bool check = FactorySensors.OpetionsSensors.Contains(choice);
            while (!check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("--- There is no such sensor, please insert one from the existing sensors. ---\n");
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic / Signal / Light");
                choice = Console.ReadLine().ToLower();
                check = FactorySensors.OpetionsSensors.Contains(choice);
            }
            return choice;
        }
    }
}