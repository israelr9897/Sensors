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
        static public int ReturnsAverageStepsPerLevel(int id)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT avg(num_steps) av FROM successes WHERE player_id = {id};", conn);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32("av");
                }
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
            return 0;
        }
        static public void UpdatDataGameToPlayer(Player player, int AID, int numSteps)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand("INSERT INTO successes(player_id,agent_id,level,num_steps) VALUES(@player_id,@agent_id,@level,@num_steps)", conn);
                cmd.Parameters.AddWithValue("@player_id", player.ID);
                cmd.Parameters.AddWithValue("@agent_id", AID);
                cmd.Parameters.AddWithValue("@level", player.Level);
                cmd.Parameters.AddWithValue("@num_steps", numSteps);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
        }
        static public Player FindPlayerByCP(string codePlayer)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT * FROM players WHERE code_player = '{codePlayer}'", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                System.Console.WriteLine(reader.Read());
                return Functions.ReturnObjPlayer(reader);
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
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
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
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
                var cmd = new MySqlCommand($"INSERT INTO players(name,code_player) VALUES(@name,@code_player)", conn);
                cmd.Parameters.AddWithValue(@"name", name);
                cmd.Parameters.AddWithValue(@"code_player", codePlayer);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
        }
        static public void UpdatePlayer(Player player)
        {
            try
            {
                int avgSteps = ReturnsAverageStepsPerLevel(player.ID);
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"UPDATE players SET last_level = @last_level, num_game = @num_game, avg_steps = @avg_steps WHERE id = {player.ID};", conn);
                cmd.Parameters.AddWithValue(@"last_level", player.Level);
                cmd.Parameters.AddWithValue(@"num_game", player.NumGame + 1);
                cmd.Parameters.AddWithValue(@"avg_steps", avgSteps);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
        }
    }
}