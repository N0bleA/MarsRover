using MarsRover_Core.Interfaces;
using MarsRover_Model;
using MarsRover_Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class InputManager : IInputManager
    {

        private readonly ICommandParser _commandParser;
        private readonly IPlateauCommandExecuter _plateauCommandExecuter;
        private readonly IDeployRoverCommandExecuter _deployRoverCommandExecuter;
        private readonly ICreatePlateau _createPlateau;
        private readonly IDeployRover _deployRover;
        private readonly IInstructionExecuter _instructionExecuter;


        public InputManager( 
            ICommandParser commandParser, 
            IPlateauCommandExecuter plateauCommandExecuter, 
            IDeployRoverCommandExecuter deployRoverCommandExecuter, 
            ICreatePlateau createPlateau, 
            IDeployRover deployRover,
            IInstructionExecuter instructionExecuter)
        {
            _deployRoverCommandExecuter = deployRoverCommandExecuter;
            _commandParser = commandParser;
            _plateauCommandExecuter = plateauCommandExecuter;
            _createPlateau = createPlateau;
            _deployRover = deployRover;
            _instructionExecuter = instructionExecuter;

        }
        public void SendCommand(string input)
        {
            CommandType commandType = _commandParser.ParseCommand(input);

            switch (commandType) 
            {
                case CommandType.Plateau:
                    _createPlateau.Plateau = _plateauCommandExecuter.ExecutePlateauCommand(input);
                    break;
                case CommandType.DeployRover:
                    _deployRover.Rover = _deployRoverCommandExecuter.ExecuteDeployRoverCommand(input, _createPlateau.Plateau);
                    break;
                case CommandType.MoveRover:
                    _deployRover.Rover = _instructionExecuter.ExecuteInstruction(input, _deployRover.Rover);
                    Console.WriteLine(_deployRover.Rover.ToString());
                    break;
                default:
                    throw new Exception("Invalid Input Sequence Detected. Please Enter Valid Inputs!");                   

            }

        }
    }
}
