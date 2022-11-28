using RobotsWarLibrary.Factory.Interfaces;
using RobotWarsLibrary.Enums;
using RobotWarsLibrary.Models;
using RobotWarsLibrary.Models.Implementations;
using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Factory.Implementations
{
    public class RobotFactory : IRobotFactory
    {
        public IRobot BuildRobot(IArena arena, uint x, uint y, Direction direction)
        {
            return new Robot(arena, x, y, direction);
        }
    }
}
