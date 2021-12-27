using MarsRover_Core.Interfaces;
using MarsRover_Model;
using MarsRover_Model.Entities;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class DeployRover : IDeployRover
    {
        public  List<Rover> RoverList { get;} = new List<Rover>();

        public ICreatePlateau Plateau { get; }
        public Rover LastDeployedRover { get; set; }
        public Rover Rover { get; set; }

       

        public DeployRover(ICreatePlateau plateau)
        {

            Plateau = plateau;
        }

         public Rover DeployRoverMethod(int coordinate_X, int coordinate_Y, Directions direction)
        {
            if(!IsValidDeployPosition(coordinate_X, coordinate_Y)) throw new Exception("Rover cannot be deployed. Please consider valid Position!");
    
            Rover rover = new Rover(coordinate_X, coordinate_Y, direction, Plateau.Plateau);
            RoverList.Add(rover);
            LastDeployedRover = rover;
            return rover;

        }


        bool IsValidDeployPosition(int coordinate_X, int coordinate_Y) 
        {
            if(coordinate_X < 0 || coordinate_X > Plateau.Plateau.Width) return false;   
            if (coordinate_X < 0 || coordinate_Y > Plateau.Plateau.Height) return false;
            return true;
        }

    }
}
