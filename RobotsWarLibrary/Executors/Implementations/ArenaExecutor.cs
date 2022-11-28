using RobotsWarLibrary.Executors.Interfaces;
using RobotsWarLibrary.Factory.Interfaces;
using RobotsWarLibrary.Validators;
using RobotWarsLibrary.Executors.Interfaces;
using System.Text.RegularExpressions;

namespace RobotWarsLibrary.Executors.Implementations
{
    public class ArenaExecutor : IExecutor
    {
        private const string arenaPositionX = "ArenaPositionX";
        private const string arenaPositionY = "ArenaPositionY";
        private readonly IContext _context;
        private readonly IInputValidator _validator;
        private readonly IArenaFactory _arenaFactory;

        public string regexPattern { get; set; }

        public ArenaExecutor(IContext context,IInputValidator validator,IArenaFactory arenaFactory)
        {
            _context = context;
            _validator = validator;
            _arenaFactory = arenaFactory;
            regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", arenaPositionX, arenaPositionY);
        }

        public void Execute(string input)
        {
            if (!_validator.TryValidateInput(input, regexPattern, out Match match))
            {
                return;
            }
            var positionX = Convert.ToUInt32(match.Groups[arenaPositionX].Value);
            var positionY = Convert.ToUInt32(match.Groups[arenaPositionY].Value);
            _context.Arena = _arenaFactory.BuildArena(positionX, positionY);
        }
    }
}
