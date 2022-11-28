using RobotWarsLibrary.Models.Interfaces;
using RobotWarsLibrary.Models;

namespace RobotsWarLibrary.Executors.Interfaces
{
    public interface IContext
    {
        IArena Arena { get; set; }
        IRobot Robot { get; set; }
    }
}

