using MarsRover_Core.Interfaces;
using MarsRover_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Services
{
    public class CreatePlateau : ICreatePlateau
    {
        public Plateau Plateau { get; set; }

        public void SetSize(int width, int height)
        {
            Plateau = new Plateau(width, height);
        }
    }
}
