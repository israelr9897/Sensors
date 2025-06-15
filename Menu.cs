namespace Sensors.models
{
    public class Menu
    {
        static internal void StMenu()
        {
            int IsTrue = 0;
            Agent a = Factory.FactoryAgent();

            // foreach (var item in a.GetSensorsList())
            // {
            //     ;
            //     }
            while (IsTrue != 2)
            {
                for (int i = 0; i < 3; i++)
                {


                    System.Console.WriteLine("choice a Sensor Audio or Thermal");
                    string choice = Console.ReadLine();
                    a._sensorsList.Add(choice);
                    
                    for (int i = 0; i < a.GetSensorsList().Count; i++)
                    {
                        if (a.GetSensorsList()[i].Active(a))
                        {
                            {
                                IsTrue++;
                            }
                        }

                    } 
                    
                    System.Console.WriteLine($"{IsTrue}/2");
                    if (IsTrue == 2)
                    {
                        break;
                    }
                }
                a._sensorsList = new List<string>();
                IsTrue = 0;
               
            }

        }
    }
}