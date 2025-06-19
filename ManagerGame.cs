namespace Sensors.models
{
    internal class ManagerGame
    {
        internal static int NumOfSensors;
        internal static int NumAttempts = 0;
        internal static int CounterToStepes = 0;
        internal static int CounterAttack = 0;
        internal static Agent IranAgent;
        internal static Player player;
        internal static Dictionary<string, List<bool>> PlayerSensors = new Dictionary<string, List<bool>>();
        internal static List<Agent> AgenetsToGame = new List<Agent>();
        protected void EnterUserToGame()
        {
            string codePlayer = Prints.PREEnter();;
            while (!DalPlayer.ChecksIfPlayerExistsByCodePlayer(codePlayer))
            {
                Prints.PRPlayerCodeError();
                codePlayer = Console.ReadLine();
                if (codePlayer == "1")
                {
                    Prints.PRInputFullName();
                    codePlayer = Registration();
                }
            }
            player = DalPlayer.FindPlayerByCP(codePlayer);
        }
        internal static string Registration()
        {
            string name = Console.ReadLine();
            string codePlayer = Functions.CreatCodePlayer(name);
            DalPlayer.AddPlayer(name, codePlayer);
            Prints.PRRegistrationMessage(name, codePlayer);
            return codePlayer;
        }
        protected void IsTenTries()
        {
            if (CounterToStepes % 10 == 0)
            {
                Prints.PRTenTries();
                ReasetFilds();
            }
        }
        protected void AddDictOfPlayer(string key)
        {
            if (!PlayerSensors.ContainsKey(key))
            {
                PlayerSensors[key] = new List<bool> { false };
            }
            else
            {
                PlayerSensors[key].Add(false);
            }
        }
        protected int SumAllSensorIsExists()
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
        protected void ChecksIfSensorExists()
        {
            foreach (var sensor in IranAgent.GetSensitiveSensors())
            {
                if (sensor.Active())
                {
                    break;
                }
            }
        }
        protected bool IsWin()
        {
            Prints.PRWinLevel();
            DalPlayer.UpdatDataGameToPlayer(player, IranAgent.ID, CounterAttack);
            player.Level++;
            if (player.Level == 5)
            {
                player.Level = 4;
                Prints.PrintWin();
                DalPlayer.UpdatePlayer(player);
                return true;
            }
            return false;
        }
        protected string InputAndCheckChoice()
        {
            Prints.PRchoiceSensor();
            string choice = Console.ReadLine().ToLower();
            bool check = FactorySensors.OpetionsSensors.Contains(choice);
            while (!check)
            {
                Prints.PRnoSuchSensor();
                Prints.PRchoiceSensor();
                choice = Console.ReadLine().ToLower();
                check = FactorySensors.OpetionsSensors.Contains(choice);
            }
            return choice;
        }
        protected void ReasetFilds()
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
    }
}