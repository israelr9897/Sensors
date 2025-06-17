namespace Sensors.models
{
    internal class FactoryAgents
    {
        private static List<string> OpetionsAgents = new List<string> { "Junior", "SquadLeader", "SeniorCommander"};
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
            int Len = AgentsNames.Count;
            Random random = new Random();
            string name = AgentsNames[random.Next(Len)];
            switch (type)
            {
                case "Junior":
                    return new JuniorAgent(name, FactorySensors.FactoryList(2));

                case "SquadLeader":
                    return new SquadLeader(name, FactorySensors.FactoryList(4));

                case "SeniorCommander":
                    return new SeniorCommander(name, FactorySensors.FactoryList(6));
            }
            return null;
        }
    }
}