using RobotWarsLibrary.Enums;
using RobotWarsLibrary.Models;
using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Factory.Interfaces
{
    public interface IRobotFactory
    {
        IRobot BuildRobot(IArena arena, uint x, uint y, Direction direction = Direction.North);
    }
}
