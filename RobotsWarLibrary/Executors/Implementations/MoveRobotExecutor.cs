using RobotsWarLibrary.Executors.Interfaces;
using RobotWarsLibrary.Executors.Interfaces;
using ICommand = RobotsWarLibrary.Commands.ICommand;
using RobotsWarLibrary.Logging;
using RobotsWarLibrary.Validators;
using RobotWarsLibrary.Enums;

namespace RobotsWarLibrary.Executors.Implementations
{
    public class MoveRobotExecutor : IExecutor
    {
        private readonly IContext _context;
        private readonly IInputValidator _validator;
        private readonly ILogger _logger;
        private IEnumerable<ICommand> Commands { get; }
        public string regexPattern { get; set; }

        public MoveRobotExecutor(IContext context, IEnumerable<ICommand> commands,
                                 IInputValidator validator, ILogger logger)
        {
            _context = context;
            _logger = logger;
            Commands = commands;
            _validator = validator;
            regexPattern = string.Format("^[m|r|l]+$");
        }

        public void Execute(string input)
        {
            if (!_validator.IsInputValid(input, regexPattern))
            {
                _logger.Log("error in moving the Robot.\n Enter quit to exit the game and start again!!");
                return;
            }
            var robot = _context.Robot;
            foreach (var character in input.ToLowerInvariant())
            {
                var command = GetCommand(character)!;
                command?.Invoke(character, robot);
            }
            var direction = GetDirectionValue(robot.Direction);
            _logger.Log(string.Format($"{robot.RobotPositionX} {robot.RobotPositionY} {direction}"));
        }

        private ICommand? GetCommand(char character)
        {
            return Commands.FirstOrDefault(z => z.IsCommandValid(character));
        }

        private string GetDirectionValue(Direction direction)
        {
            return direction switch
            {
                Direction.East => "E",
                Direction.South => "S",
                Direction.West => "W",
                _ => "N"
            };
        }
    }
}
