using MySql.Data.MySqlClient;

namespace Sensors.models
{
    internal class DalPlayer
    {
        static public MySqlConnect _MySql;
        internal DalPlayer(MySqlConnect mySql)
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
        static public Player FindPlayerByCP(string codePlayer)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT * FROM players WHERE code_player = '{codePlayer}'", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return Functions.ReturnObjPlayer(reader);
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
                var cmd = new MySqlCommand($"SELECT last_level FROM players WHERE code_player = '{CP}';", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32("last_level");
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
    }
}