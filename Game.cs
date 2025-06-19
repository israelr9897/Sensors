using System.Numerics;

namespace Sensors.models
{
    internal class Game : ManagerGame
    {
        private static Game _instansce;
        // private static int NumOfSensors;
        // internal static int NumAttempts = 0;
        // internal static int CounterToStepes = 0;
        // internal static int CounterAttack = 0;
        // internal static Agent IranAgent;
        // internal static Player player;
        // internal static Dictionary<string, List<bool>> PlayerSensors = new Dictionary<string, List<bool>>();
        // internal static List<Agent> AgenetsToGame = new List<Agent>();


        private Game()
        {
            MySqlConnect conn = new MySqlConnect();
            conn.connect();
            new DalPlayer(conn);
            new DalAgents(conn);
            FlowGame();
        }
        public static Game GetInstance()
        {
            if (_instansce == null)
            {
                _instansce = new Game();
            }
            return _instansce;
        }
        private void StartGame()
        {
            CreateIranAgent();
            ReasetFilds();
            Prints.PRWelcome();
            CounterToStepes = 0;
        }
        private void FlowGame()
        {
            EnterUserToGame();
            StartGame();     
            while (true)
            {
                CounterAttack++;
                CounterToStepes++;
                string choice = InputAndCheckChoice();
                AddDictOfPlayer(choice);
                ChecksIfSensorExists();
                NumAttempts = SumAllSensorIsExists();
                Prints.PRAnswer();
                IranAgent.Attack();
                if (SumAllSensorIsExists() == NumOfSensors)
                {
                    if (IsWin())
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
        private void CreateIranAgent()
        {
            switch (Game.player.Level)
            {
                case 1:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("Junior");
                    NumOfSensors = Game.IranAgent.GetSensitiveSensors().Count;
                    break;
                case 2:
                    IranAgent = FactoryAgents.FactoryJuniorAgent("SquadLeader");
                    NumOfSensors = Game.IranAgent.GetSensitiveSensors().Count;
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
            DalAgents.UpdateAgents(IranAgent);
            AgenetsToGame.Add(IranAgent);
        }
        
        
    }
}