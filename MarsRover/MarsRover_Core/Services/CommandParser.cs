using MarsRover_Core.Interfaces;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover_Core.Services
{
    public class CommandParser : ICommandParser
    {

        private readonly Regex PlateauRegex = new Regex("^\\d+ \\d+$");
        private readonly Regex DeployRoverRegex = new Regex($"^\\d+ \\d+ [{ string.Join("", Enum.GetNames(typeof(Directions))) }]$");
        private readonly Regex MoveRoverRegex = new Regex($"^[{string.Join("", Enum.GetNames(typeof(InstructionType)))}]+$");

        public CommandType ParseCommand(string command)
        {
            var trimmedCommand = command.Trim();

            if (PlateauRegex.IsMatch(trimmedCommand)) return CommandType.Plateau;
            if (DeployRoverRegex.IsMatch(trimmedCommand)) return CommandType.DeployRover;
            if (MoveRoverRegex.IsMatch(trimmedCommand)) return CommandType.MoveRover;

            return CommandType.Invalid;  
        }
    }
}
