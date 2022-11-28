using RobotsWarLibrary.Executors.Interfaces;
using RobotWarsLibrary.Models;
using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Executors.Implementations
{
    public class Context : IContext
    {
        public IArena Arena { get; set; }
        public IRobot Robot { get; set; }
    }
}
