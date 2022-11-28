using RobotWarsLibrary.Enums;

namespace RobotWarsLibrary.Models.Interfaces
{
    public interface IRobot
    {
        Direction Direction { get; }
        uint RobotPositionX { get; }
        uint RobotPositionY { get; }
        IArena Arena { get; set; }
        void MoveForward();
        void Spin(bool clockwise);
    }
}
