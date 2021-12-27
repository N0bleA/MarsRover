using MarsRover_Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface IInstructionExecuter
    {
        Rover ExecuteInstruction(string input,Rover rover);
    }
}
