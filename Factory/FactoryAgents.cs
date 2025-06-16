namespace Sensors.models
{
    internal class FactoryAgents
    {
        private static List<string> OpetionsAgents = new List<string> { "Junior", "SquadLeader"};
        internal static Agent FactoryJuniorAgent(string name)
        {
            int Len = OpetionsAgents.Count;
            Random random = new Random();
            string type = OpetionsAgents[random.Next(Len)];
            switch (type)
            {
                case "Junior":
                    return new JuniorAgent(name, FactorySensors.FactoryList(2));

                case "SquadLeader":
                    return new SquadLeader(name, FactorySensors.FactoryList(4));
            }
            return null;
        }
    }
}