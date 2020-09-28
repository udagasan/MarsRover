using Constants;
using Exception;
using Extensions;
using System;

namespace Solution
{
    public class Controller
    {
        public void ControlsOfInputValues(Input input)
        {
            if (input==null)
            {
                throw new ArgumentNullException(Messages.NullParamether);
            }
            if (input.Moves.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(Messages.MoveDirectionCanNotBeEmpty);
            }
            foreach (var item in input.Moves)
            {
                if (!(item.Equals("L")|| item.Equals("M") || item.Equals("R") ))
                {
                    throw new InvalidCharacterException(item.ToString());
                }
            }
            if (input.Coorinates.X < 0 || input.Coorinates.X > input.MaxPoints.X ||
                  input.Coorinates.Y < 0 || input.Coorinates.Y > input.MaxPoints.Y)
            {
                throw new ArgumentOutOfRangeException($"Pozisyon (0,0) ve {input.MaxPoints.X} , {input.MaxPoints.Y} " +
                    $"aralığğında olmalıdır");
            }
        }
    }
}
