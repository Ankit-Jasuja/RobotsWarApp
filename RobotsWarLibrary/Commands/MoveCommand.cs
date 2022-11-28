using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Commands
{
    public class MoveCommand : ICommand
    {
        public void Invoke(char command, IRobot robot)
        {
            if (IsCommandValid(command) && robot is not null)
                robot.MoveForward();
        }

        public bool IsCommandValid(char character)
        {
            return character == 'M' || character == 'm';
        }
    }
}
