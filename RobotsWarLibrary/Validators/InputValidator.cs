using RobotWarsLibrary.Models;
using System.Text.RegularExpressions;

namespace RobotsWarLibrary.Validators
{
    public class InputValidator : IInputValidator
    {
        public bool IsInputValid(string input, string regexPattern)
        {
            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(input);
        }

        public bool TryValidateInput(string input, string regexPattern, out Match match)
        {
            var regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            match = regex.Match(input);
            return match.Success;
        }

        public bool IsRobotValid(IArena arena, uint x, uint y)
        {
            if (arena == null || x > arena.ArenaPositionX || y > arena.ArenaPositionY)
            {
                return false;
            }
            return true;
        }
    }
}
