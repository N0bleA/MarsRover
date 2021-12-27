using MarsRover_Model;
using MarsRover_Model.Entities;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface IDeployRover
    {
        List<Rover> RoverList { get; }
        Rover Rover { get; set; }
        Rover DeployRoverMethod(int Coordinate_X,int Coordinate_Y, Directions direction);
        ICreatePlateau Plateau { get;  }
        Rover LastDeployedRover { get; set; }


    }
}
