using Constants;

namespace Solution
{
    public class DirectionDispatcher
    {
        public DirectionDispatcher()
        {

        }

        public static void RotateToLeft90Degrees(Directions Direction, Coorinates Coorinates)
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.West;
                    break;
                case Directions.South:
                    Direction = Directions.East;
                    break;
                case Directions.East:
                    Direction = Directions.North;
                    break;
                case Directions.West:
                    Direction = Directions.South;
                    break;
                default:
                    break;
            }
        }
        public static void RotateToRight90Degrees(Directions Direction, Coorinates Coorinates)
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
                default:
                    break;
            }
        }
        public static void MoveInSameDirection(Directions Direction, Coorinates Coorinates)
        {
            switch (Direction)
            {
                case Directions.North:
                    Coorinates.Y += 1;
                    break;
                case Directions.South:
                    Coorinates.Y -= 1;
                    break;
                case Directions.East:
                    Coorinates.X += 1;
                    break;
                case Directions.West:
                    Coorinates.X -= 1;
                    break;
                default:
                    break;
            }
        }
    }

}
