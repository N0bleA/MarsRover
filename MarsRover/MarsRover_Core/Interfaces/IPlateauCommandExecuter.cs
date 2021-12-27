using MarsRover_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface IPlateauCommandExecuter
    {
        Plateau ExecutePlateauCommand(string input);
    }
}
