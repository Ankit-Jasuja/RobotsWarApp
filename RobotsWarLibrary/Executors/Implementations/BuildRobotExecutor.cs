using RobotsWarLibrary.Executors.Interfaces;
using RobotsWarLibrary.Factory.Interfaces;
using RobotsWarLibrary.Logging;
using RobotsWarLibrary.Validators;
using RobotWarsLibrary.Enums;
using RobotWarsLibrary.Executors.Interfaces;
using System.Text.RegularExpressions;

namespace RobotsWarLibrary.Executors.Implementations
{
    public class BuildRobotExecutor : IExecutor
    {
        private const string robotPositionX = "RobotPositionX";
        private const string robotPositionY = "RobotPositionY";
        private const string direction = "Direction";
        private readonly ILogger _logger;
        private readonly IContext _context;
        private readonly IInputValidator _validator;
        private readonly IRobotFactory _robotFactory;

        public string regexPattern { get; set; }

        public BuildRobotExecutor(IContext context, IInputValidator validator, 
                                  IRobotFactory robotFactory, ILogger logger)
        {
            _context = context;
            _validator = validator;
            _robotFactory = robotFactory;
            _logger = logger;
            regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$",
                           robotPositionX, robotPositionY, direction);
        }
        public void Execute(string input)
        {
            if (!_validator.TryValidateInput(input, regexPattern, out Match match))
            {
                return;
            }
            var positionX = Convert.ToUInt32(match.Groups[robotPositionX].Value);
            var positionY = Convert.ToUInt32(match.Groups[robotPositionY].Value);
            var direct = ConvertToDirection(match.Groups[direction].Value);

            if (_validator.IsRobotValid(_context.Arena, positionX, positionY))
            {
                _context.Robot = _robotFactory.BuildRobot(_context.Arena, positionX, positionY, direct);
            }
            else
            {
                _logger.Log("error in building the Robot.\n Enter quit to exit the game and start again!!");
                return;
            }
        }

        private Direction ConvertToDirection(string value)
        {
            return value.ToLowerInvariant() switch
            {
                "e" => Direction.East,
                "s" => Direction.South,
                "w" => Direction.West,
                _ => Direction.North,
            };
        }
    }
}
