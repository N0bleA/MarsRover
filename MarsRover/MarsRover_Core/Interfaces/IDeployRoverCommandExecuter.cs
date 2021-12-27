using MarsRover_Model;
using MarsRover_Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface IDeployRoverCommandExecuter
    {
        Rover ExecuteDeployRoverCommand(string input, Plateau plateau);
    }
}
