using MySql.Data.MySqlClient;

namespace Sensors.models
{
    internal class DalAgents
    {
        static public MySqlConnect _MySql;
        internal DalAgents(MySqlConnect mySql)
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
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Error: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
            return false;
        }
        static public string ReturnRandomAgent()
        {
            try
            {
                string idAndName;
                Random random = new Random();
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT COUNT(*)c FROM agents", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                int num = reader.GetInt32("c");
                reader.Close();
                var cmd2 = new MySqlCommand($"SELECT * FROM agents WHERE id = {random.Next(1, num+1)}", conn);
                reader = cmd2.ExecuteReader();
                reader.Read();
                idAndName = reader.GetInt32("id").ToString() + ",";
                idAndName += reader.GetString("name");
                return idAndName;
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
        static public Agent FindAgentByID(int id)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"SELECT * FROM agents WHERE id = '{id}'", conn);
                var reader = cmd.ExecuteReader();
                reader.Read();
                return Functions.ReturnObjAgent(reader);
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
        static public void UpdateAgents(Agent agent)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"UPDATE agents SET rank = @rank, sensitive_sensors = @sensitive_sensors WHERE id = {agent.ID};", conn);
                cmd.Parameters.AddWithValue(@"rank", agent.GetRankForAgent());
                cmd.Parameters.AddWithValue(@"sensitive_sensors", Functions.ReturnStringOfSensors(agent.GetSensitiveSensors()));
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