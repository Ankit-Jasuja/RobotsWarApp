using RobotWarsLibrary.Enums;
using RobotWarsLibrary.Models.Interfaces;

namespace RobotWarsLibrary.Models.Implementations
{
    public class Robot : IRobot
    {
        public Robot(IArena arena,uint x, uint y, Direction direction)
        {
            Arena = arena;
            RobotPositionX = x;
            RobotPositionY = y;
            Direction = direction;
        }

        public Direction Direction { get; private set; }
        public uint RobotPositionX { get; private set; }
        public uint RobotPositionY { get; private set; }
        public IArena Arena { get; set; }

        public void MoveForward()
        {
            if (Arena == null)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.East:
                    if (RobotPositionX < Arena.ArenaPositionX)
                    {
                        RobotPositionX++;
                    }
                    break;
                case Direction.North:
                    if (RobotPositionY < Arena.ArenaPositionY)
                    {
                        RobotPositionY++;
                    }
                    break;
                case Direction.South:
                    if (RobotPositionY > 0)
                    {
                        RobotPositionY--;
                    }
                    break;
                case Direction.West:
                    if (RobotPositionX > 0)
                    {
                        RobotPositionX--;
                    }
                    break;
            }
        }

        public void Spin(bool clockwise)
        {
            if (clockwise)
            {
                Direction = Direction == Direction.West ? Direction.North
                                                                       : (Direction)(((int)Direction) << 1);
            }
            else
            {
                Direction = Direction == Direction.North ? Direction.West
                                                                        : (Direction)(((int)Direction) >> 1);
            }
        }
    }
}
