using RobotsWarLibrary.Factory.Interfaces;
using RobotWarsLibrary.Models;

namespace RobotsWarLibrary.Factory.Implementations
{
    public class ArenaFactory : IArenaFactory
    {
        public IArena BuildArena(uint positionX, uint positionY)
        {
            return new Arena(positionX, positionY);
        }
    }
}
