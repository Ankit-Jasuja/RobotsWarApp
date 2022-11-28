namespace RobotWarsLibrary.Models
{
    public class Arena : IArena
    {
        public Arena(uint x, uint y)
        {
            ArenaPositionX = x;
            ArenaPositionY = y;
        }

        public uint ArenaPositionX { get; private set; }
        public uint ArenaPositionY { get; private set; }
    }
}
