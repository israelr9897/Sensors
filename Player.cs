namespace Sensors.models
{
    internal class Player
    {
        internal int ID;
        internal int NumGame;
        internal string Name;
        internal string CodePlayer;
        internal int Level;
        internal Player(string name, string codePlayer, int level, int id, int numGame)
        {
            Name = name;
            CodePlayer = codePlayer;
            Level = level;
            ID = id;
            NumGame = numGame;
        }
        internal Player(string name, string codePlayer, int level)
        {
            Name = name;
            CodePlayer = codePlayer;
            Level = level;
        }
    }
}