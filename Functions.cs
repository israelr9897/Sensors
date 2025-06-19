using MySql.Data.MySqlClient;

namespace Sensors.models
{
    internal class Functions
    {
        internal static Player ReturnObjPlayer(MySqlDataReader reader)
        {
            Player player = new Player(
               reader.GetString("name"),
               reader.GetString("Code_player"),
               reader.GetInt32("last_level")
           );
            return player;
        }
        static public string CreatCodePlayer(string fullName)
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
    }
}