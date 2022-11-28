using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Commands
{
    public interface ICommand
    {
        void Invoke(char command, IRobot robot);
        bool IsCommandValid(char command);
    }
}
