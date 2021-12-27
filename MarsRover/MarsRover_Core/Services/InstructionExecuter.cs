using MarsRover_Core.Extensions;
using MarsRover_Core.Interfaces;
using MarsRover_Model.Entities;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class InstructionExecuter : IInstructionExecuter
    {
        public Rover ExecuteInstruction(string input,Rover rover)
        {
  
                foreach (var instruction in input?.ToEnumList<InstructionType>())
                {
                    switch (instruction)
                    {
                        case InstructionType.L:
                            TurnLeft(rover);
                            break;
                        case InstructionType.R:
                            TurnRight(rover);
                            break;
                        case InstructionType.M:
                            MoveForward(rover);
                            break;
                        default:
                            throw new Exception("Unknown command detected!");
                    }
                }
            return rover;
      
        }

        private void MoveForward(Rover rover)
        {
            switch (rover.Directions)
            {
                case Directions.N:
                    if (rover.Coordinate_Y + 1 <= rover.Plateau.Height)
                        rover.Coordinate_Y += 1;
                    else
                    {
                        throw new Exception("You cant move!. You have reached the upper level boundry!");
                    }
                    break;

                case Directions.E:
                    if (rover.Coordinate_X + 1 <= rover.Plateau.Width)
                        rover.Coordinate_X += 1;
                    else
                    {
                        throw new Exception("You cant move!. You have reached the right level boundry!");
                    }
                    break;

                case Directions.S:
                    if (rover.Coordinate_Y - 1 >= 0)
                        rover.Coordinate_Y -= 1;
                    else
                    {
                        throw new Exception("You cant move!. You have reached the bottom level boundry!");
                    }
                    break;

                case Directions.W:
                    if (rover.Coordinate_X - 1 >= 0)
                        rover.Coordinate_X -= 1;
                    else
                    {
                        throw new Exception("You cant move!. You have reached the left level boundry!");
                    }
                    break;
            }
        }

        private void TurnLeft(Rover rover)
        {
            rover.Directions = rover.Directions switch
            {
                Directions.N => Directions.W,
                Directions.W => Directions.S,
                Directions.S => Directions.E,
                Directions.E => Directions.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private void TurnRight(Rover rover)
        {
            rover.Directions = rover.Directions switch
            {
                Directions.N => Directions.E,
                Directions.W => Directions.N,
                Directions.S => Directions.W,
                Directions.E => Directions.S,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }


}
