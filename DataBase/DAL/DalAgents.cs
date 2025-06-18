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
                System.Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }
            finally
            {
                _MySql.Disconnect();
            }
            return false;
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
        private static string ReturnStringOfSensors(List<Sensor> senList)
        {
            string strSensors = "";
            foreach (var sensor in senList)
            {
                strSensors += sensor.Type;
                strSensors += " , ";
            }
            return strSensors;
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
                var cmd2 = new MySqlCommand($"SELECT * FROM agents WHERE id = {random.Next(1, num)}", conn);
                reader = cmd2.ExecuteReader();
                reader.Read();
                idAndName = reader.GetInt32("id").ToString() + ",";
                idAndName += reader.GetString("name");
                return idAndName;
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
                return ReturnObjAgent(reader);
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
        static public void UpdateAgents(Agent agent)
        {
            try
            {
                MySqlConnection conn = _MySql.GetConnect();
                var cmd = new MySqlCommand($"INSERT INTO agents(name,rank,sensitive_sensors)VALUES(@name,@rank,@sensitive_sensors)", conn);
                cmd.Parameters.AddWithValue(@"name", agent.Name);
                cmd.Parameters.AddWithValue(@"sensitive_sensors", ReturnStringOfSensors(agent.GetSensitiveSensors()));
                cmd.Parameters.AddWithValue(@"rank", agent.GetRankForAgent());
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