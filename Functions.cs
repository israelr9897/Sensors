using MySql.Data.MySqlClient;

namespace Sensors.models
{
    internal class Functions
    {
        internal static Player ReturnObjPlayer(MySqlDataReader reader)
        {
            Player player = new Player(
               reader.GetString("name"),
               reader.GetString("code_player"),
               reader.GetInt32("last_level"),
               reader.GetInt32("ID"),
               reader.GetInt32("num_game")
           );
            return player;
        }
        internal static string ReturnTimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
        internal static string CreatCodePlayer(string fullName)
        {
            string FN = fullName.Split(" ")[0];
            string LN = fullName.Split(" ")[1];
            string str = $"{FN[0]}{FN[FN.Length / 2]}{FN[^1]}{LN[0]}{LN[LN.Length / 2]}{LN[^1]}";
            string codePlayer = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    codePlayer += (str[i] + 0).ToString();
                }
                else
                {
                    codePlayer += str[i];
                }
            }
            return codePlayer;
        }
        internal static Agent ReturnObjAgent(MySqlDataReader reader)
        {
            Agent agent = new Agent(
               reader.GetInt32("id"),
               reader.GetString("name"),
               reader.GetString("rank"),
               ReturnSensorsList(reader.GetString("sensitive_sensors"))
           );
            return agent;
        }
        internal static string ReturnStringOfSensors(List<Sensor> senList)
        {
            string strSensors = "";
            foreach (var sensor in senList)
            {
                strSensors += sensor.Type;
                strSensors += " , ";
            }
            return strSensors;
        }
        private static List<Sensor> ReturnSensorsList(string strSensors)
        {
            List<Sensor> sensorsList = new List<Sensor>();
            foreach (var type in strSensors.Split(","))
            {
                sensorsList.Add(FactorySensors.CreateInstans(type));
            }
            return sensorsList;
        }
    }
}