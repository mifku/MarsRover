using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Plateau()
        {
        }
    }
}
