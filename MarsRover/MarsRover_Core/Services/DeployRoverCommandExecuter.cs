using MarsRover_Core.Extensions;
using MarsRover_Core.Interfaces;
using MarsRover_Model;
using MarsRover_Model.Entities;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class DeployRoverCommandExecuter : IDeployRoverCommandExecuter
    {
        private readonly IDeployRover _deployRover;

        public DeployRoverCommandExecuter(IDeployRover deployRover)
        {
            _deployRover = deployRover;

        }
        public Rover ExecuteDeployRoverCommand(string input,Plateau plateau)
        {
            _deployRover.Plateau.Plateau = plateau;
            var splittedInput = input.Split(' ');
            return _deployRover.DeployRoverMethod(int.Parse(splittedInput[0]),int.Parse(splittedInput[1]), splittedInput[2].ToEnum<Directions>());
           
        }

    }
}
