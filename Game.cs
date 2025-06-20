using System.Numerics;

namespace Sensors.models
{
    internal class Game : ManagerGame
    {
        private static Game _instansce;
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
        internal static void StartGame()
        {
            CreateIranAgent();
            ReasetFilds();
            Prints.PRWelcome();
            CounterToStepes = 0;
        }
        private void FlowGame()
        {
            EnterUserToGame();
            Prints.PRPlayerDetails();
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
                EndOfPhaseCheck();
            }
        }
    }
}