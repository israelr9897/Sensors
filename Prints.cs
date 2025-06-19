namespace Sensors.models
{
    internal static class Prints
    {
        internal static string PREEnter()
        {
            System.Console.WriteLine("Enter your player code - ");
            System.Console.WriteLine("To register click 1");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                return ManagerGame.Registration();;
            }
            return choice;
        }
        internal static void PRInputFullName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("What your  - Full Name - ? ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void PRPlayerCodeError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nYour player code not found\n");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Enter again");
            System.Console.WriteLine("Or Press 1 to re-register");
        }
        internal static void PRRegistrationMessage(string name, string CP)
        {
            System.Console.WriteLine("-- √ Registration Successful √ --");
            System.Console.WriteLine($"-- Name: {name} --");
            System.Console.WriteLine($"-- Player Code: {CP} --");
        }
        internal static void PRWinLevel()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine($"\nCongratulations!! You have completed the step - {ManagerGame.player.Level}\n");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        internal static void PrintWin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\nYou won!!!!! You managed to find all the correct sensors\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void PRchoiceSensor()
        {
            System.Console.WriteLine("choice a Sensor Audio / Thermal / Pulse / Motion / Magnetic / Signal / Light");
        }
        internal static void PRnoSuchSensor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("--- There is no such sensor, please insert one from the existing sensors. ---\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void PRTenTries()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("\nIt's been 10 tries !!! you'll have to start all over again.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static void PRWelcome()
        {
            System.Console.WriteLine("\n-------- Welcome --------\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine($"-------- Level {ManagerGame.player.Level} --------\n");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"Name: {ManagerGame.IranAgent.Name}");
            System.Console.WriteLine("Waiting for you in the interrogation room.\n");
        }
        internal static void PRAnswer()
        {
            System.Console.WriteLine("These are the sensors you've attached so far - \n");
            foreach (var sensor in ManagerGame.PlayerSensors)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                System.Console.WriteLine(" - " + sensor.Key);   
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou were right - {ManagerGame.NumAttempts}/{ManagerGame.NumOfSensors}");
            Console.ForegroundColor = ConsoleColor.White;
        }


        
    }
}