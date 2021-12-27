using System;

namespace MarsRover_Model
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau(int x,int y) 
        {
            Width = x;
            Height = y;
        }
    }
    
}
