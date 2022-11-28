using RobotWarsLibrary.Models.Interfaces;

namespace RobotsWarLibrary.Commands
{
    public class SpinCommand : ICommand
    {
        private const char rightCommand = 'R';
        private const char leftCommand = 'L';

        public void Invoke(char character, IRobot robot)
        {
            if(IsCommandValid(character) && robot is not null)
            Spin(character, robot);
        }

        public bool IsCommandValid(char character)
        {
            return IsLeftCommand(character)
                || IsRightCommand(character);
        }

        private void Spin(char character, IRobot robot)
        {
            if (IsLeftCommand(character))
            {
                robot.Spin(false);
            }

            if (IsRightCommand(character))
            {
                robot.Spin(true);
            }
        }

        private bool IsRightCommand(char command)
        {
            return char.ToUpperInvariant(command) == rightCommand;
        }

        private bool IsLeftCommand(char command)
        {
            return char.ToUpperInvariant(command) == leftCommand;
        }
    }
}
