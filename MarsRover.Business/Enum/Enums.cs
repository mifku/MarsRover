using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Business
{   
    public static class Enums
    {
        public static List<string> GetNamesOfDirections()
        {
            return new List<string>(Enum.GetNames(typeof(Direction)));
        }
        public static List<string> GetValuesOfCommands()
        {
            var list = new List<string>();
            var arr = Enum.GetValues(typeof(Command));
            foreach (var item in arr)
            {
                list.Add(item.ToString().First().ToString());
            }
            return list;
        }
    }
    /// <summary>
    /// Directions are enumarated by clockwise
    /// </summary>
    public enum Direction
    {

        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public enum Command
    {
        Left = 'L',
        Right = 'R',
        Move = 'M'
    }

    
   
}
