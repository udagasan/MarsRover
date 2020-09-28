using Constants;
using System;

namespace Solution
{
    public class RoboticRover
    {

        private Coorinates Coorinates { get; set; }
        private Directions Direction { get; set; }

        public RoboticRover()
        {
            Coorinates = new Coorinates(0, 0);
            Direction = Directions.North;
        }

        private void RotateToLeft90Degrees()
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

        private void RotateToRight90Degrees ()
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

        private void MoveInSameDirection()
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

        public Output Row(Input input)
        {
            Coorinates = input.Coorinates;
            Direction = input.Direction;
            foreach (var move in input.Moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInSameDirection();
                        break;
                    case 'L':
                        RotateToLeft90Degrees();
                        break;
                    case 'R':
                        RotateToRight90Degrees();
                        break;
                    default:
                        throw new ArgumentException("Geçersiz Karakter");
                }

               
            }
            return new Output { Coorinates = Coorinates, Direction = Direction };
        }
    }
}
