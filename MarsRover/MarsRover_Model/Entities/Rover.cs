using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Model.Entities
{
    public class Rover
    {
        public int Coordinate_X { get; set; }

        public int Coordinate_Y { get; set; }

        public Directions Directions { get; set; }

        public Plateau Plateau { get; set; }

        public Rover(int x,int y,Directions direction, Plateau plateau) 
        {
            Coordinate_X = x;
            Coordinate_Y = y;
            Directions = direction;
            Plateau = plateau;
        }

        public override string ToString()
        {
            return $"{Coordinate_X} {Coordinate_Y} {Directions:G}";
        }

    }
}
