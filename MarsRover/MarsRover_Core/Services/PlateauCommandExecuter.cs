using MarsRover_Core.Interfaces;
using MarsRover_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class PlateauCommandExecuter : IPlateauCommandExecuter
    {

        private readonly ICreatePlateau _createPlateau;

        public PlateauCommandExecuter(ICreatePlateau createPlateau)
        {
            _createPlateau = createPlateau;
        }
        public Plateau ExecutePlateauCommand(string input)
        {
            var splittedInput = input.Split(' ');
            _createPlateau.SetSize(int.Parse(splittedInput[0]), int.Parse(splittedInput[1]));
            return _createPlateau.Plateau;

        }
    }
}
