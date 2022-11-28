using RobotWarsLibrary.Models;
using System.Text.RegularExpressions;

namespace RobotsWarLibrary.Validators
{
    public interface IInputValidator
    {
        bool IsInputValid(string input, string regexPattern);
        bool IsRobotValid(IArena arena, uint x, uint y);
        bool TryValidateInput(string input, string regexPattern, out Match match);
    }
}
