using MySql.Data.MySqlClient;

namespace Sensors.models
{
    internal class DalPeople
    {
        static public MySqlConnect _MySql;
        internal DalPeople(MySqlConnect mySql)
        {
            _MySql = mySql;
        }

        internal static bool ChecksIfPlayerExistsByCodePlayer(string CP)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT code_player FROM players WHERE code_player = '{CP}';", conn);
                var reader = cmd.ExecuteReader();
                return reader.Read();
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
            return false;
        }
        internal static Player ReturnObjPlayer(MySqlDataReader reader)
        {
             Player player = new Player(
                reader.GetString("name"),
                reader.GetString("Code_player"),
                reader.GetInt32("level")
            );
            return player;
        }
        static public Player FindPlayerByCP(string codePlayer)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT * FROM players WHERE code_player = '{codePlayer}'", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return ReturnObjPlayer(reader);
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                _MySql.Disconnect();
            }
            return null;
        }
        internal static int GetLevelForPlayer(string CP)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT level FROM players WHERE code_player = '{CP}';", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32("level");
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
            return 1;
        }
        static public void AddPlayer(string name, string codePlayer)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"INSERT INTO players(name,code_player)VALUES(@name,@code_player)", conn);
                cmd.Parameters.AddWithValue(@"name", name);
                cmd.Parameters.AddWithValue(@"code_player", codePlayer);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                _MySql.Disconnect();
            }
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