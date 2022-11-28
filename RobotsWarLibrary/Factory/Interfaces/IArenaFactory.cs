using RobotWarsLibrary.Models;

namespace RobotsWarLibrary.Factory.Interfaces
{
    public interface IArenaFactory
    {
        IArena BuildArena(uint positionX, uint positionY);
    }
}
