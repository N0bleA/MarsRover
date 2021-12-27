using MarsRover_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover_Core.Interfaces
{
    public interface ICreatePlateau
    {
        Plateau Plateau { get; set; }
        void SetSize(int width, int height);


    }
}
