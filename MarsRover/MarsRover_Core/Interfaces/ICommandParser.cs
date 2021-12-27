using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface ICommandParser
    {
        CommandType ParseCommand(string command);

    }
}
