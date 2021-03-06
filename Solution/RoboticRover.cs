﻿using Constants;
using Exception;
using Helper;
using System;

namespace Solution
{
    public class RoboticRover
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

        private void RotateToRight90Degrees()
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

        public GenericResponse<Output> Row(Input input)
        {
            var returnObject = new GenericResponse<Output>();
            var controllerResponse = new Controller().ControlsOfInputValues(input);
            if (!controllerResponse.Success)
            {
                returnObject.Results.AddRange(controllerResponse.Results);
                return returnObject;
            }
            Coorinates = input.Coorinates;
            Direction = input.Direction;
            try
            {
                foreach (var move in input.Moves)
                {
                    switch (move)
                    {
                        case Way.Swivel:
                            MoveInSameDirection();
                            break;
                        case Way.Left:
                            RotateToLeft90Degrees();
                            break;
                        case Way.Right:
                            RotateToRight90Degrees();
                            break;
                        default:
                            throw new ArgumentException(Messages.InvalidCharacter);
                    }


                }
                returnObject.Value = new Output { Coorinates = Coorinates, Direction = Direction };

            }
            catch (InvalidCharacterException ex)
            {
                log.Error(ex);
                returnObject.Results.Add(new Result
                {
                    ErrorCode = nameof(ErrorCodes.SystemError),
                    ErrorMessage = ex.Message
                });
            }
            catch (System.Exception ex)
            {
                log.Error(ex);
                returnObject.Results.Add(new Result
                {
                    ErrorCode = nameof(ErrorCodes.SystemError),
                    ErrorMessage = ex.Message
                });
            }
            finally
            {
                if (!returnObject.Success)
                {
                    log.Error(returnObject.Results);
                }
                else
                {
                    log.Info(returnObject.Value);
                }
            }
            return returnObject;
        }
    }
}
