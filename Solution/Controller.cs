using Constants;
using Exception;
using Extensions;
using Helper;
using System;

namespace Solution
{
    public class Controller
    {
        public GenericResponse<Result> ControlsOfInputValues(Input input)
        {
            var returnObject = new GenericResponse<Result>();
            if (input==null)
            {
                returnObject.Results.Add(new Result
                {
                    ErrorCode=nameof(ErrorCodes.NullParamether),
                    ErrorMessage= Messages.NullParamether
                });
                return returnObject;
            }
            if (input.Moves.IsNullOrWhiteSpace())
            {
                returnObject.Results.Add(new Result
                {
                    ErrorCode = nameof(ErrorCodes.MoveDirectionCanNotBeEmpty),
                    ErrorMessage = Messages.MoveDirectionCanNotBeEmpty
                });
            }
            foreach (var item in input.Moves)
            {
                if (!(item.Equals(Way.Left)|| item.Equals(Way.Swivel) || item.Equals(Way.Right) ))
                {
                    returnObject.Results.Add(new Result
                    {
                        ErrorCode = nameof(ErrorCodes.InvalidCharacter),
                        ErrorMessage = Messages.InvalidCharacter
                    });
                    throw new InvalidCharacterException(item.ToString());
                }
            }
            if (input.Coorinates.X < 0 || input.Coorinates.X > input.MaxPoints.X ||
                  input.Coorinates.Y < 0 || input.Coorinates.Y > input.MaxPoints.Y)
            {
                returnObject.Results.Add(new Result
                {
                    ErrorCode = nameof(ErrorCodes.CharacterOutOfRange),
                    ErrorMessage = $"Pozisyon (0,0) ve {input.MaxPoints.X} , {input.MaxPoints.Y} " +
                    $"aralığğında olmalıdır"
                });
            }
            return returnObject;
        }
    }
}
