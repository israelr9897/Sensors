namespace Sensors.models
{
    internal class FactoryAgents
    {
        private static List<string> AgentsNames = new List<string>
            {
                "Khalid Mansour",
                "Omar Hadid",
                "Ziad Al-Najjar",
                "Nasser Abu Salem",
                "Faris Rahman",
                "Layla Nasser",
                "Mariam Zahra",
                "Yasmin Qabbani",
                "Dina Al-Fahad",
                "Rania Saeed"
            };

        internal static Agent FactoryJuniorAgent(string type)
        {
            // int Len = AgentsNames.Count;
            // Random random = new Random();
            // string name = AgentsNames[random.Next(Len)];
            string idAndName = DalAgents.ReturnRandomAgent();
            System.Console.WriteLine(idAndName);
            int id = int.Parse(idAndName.Split(",")[0]); 
            string name = idAndName.Split(",")[1];
            switch (type)
            {
                case "Junior":
                    return new JuniorAgent(id, name, FactorySensors.FactoryList(2));

                case "SquadLeader":
                    return new SquadLeader(id, name, FactorySensors.FactoryList(4));

                case "SeniorCommander":
                    return new SeniorCommander(id, name, FactorySensors.FactoryList(6));

                case "OrganizationLeader":
                    return new SeniorCommander(id, name, FactorySensors.FactoryList(8));
            }
            return null;
        }
    }
}