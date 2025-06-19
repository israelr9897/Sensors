using MySql.Data.MySqlClient;


namespace Sensors.models
{
    public class MySqlConnect
    {
        string connectString = "Server=localhost;Database=GameSensors;User=root;Password='';";
        MySqlConnection connection;

        public void connect()
        {
            var conn = new MySqlConnection(connectString);
            connection = conn;
            try
            {
                conn.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("-- Connected to MySql database --\n");
                Console.ForegroundColor = ConsoleColor.White;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Eror connecting to MySql: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public MySqlConnection GetConnect()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                return connection;
            }
            catch (MySqlException ex)
            {
                System.Console.WriteLine($"Eror connecting to MySql: {ex.Message}");
            }
            return null;
        }

        public void Disconnect()
        {
            connection.Close();
        }

    }
}