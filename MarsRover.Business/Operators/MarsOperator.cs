using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MarsRover.Business.Operators
{
    public class MarsOperator
    {
        private List<Rover> RoverList= new List<Rover>();
        private Plateau Plateau;
        public MarsOperator()
        {

        }
         
        public MarsOperator BuildSetup()
        {
            FileOperator fo = new FileOperator(ConfigurationManager.AppSettings["InputFilePath"]);
            if (!fo.Load().ValidateInputFile()) { throw new Exception("Invalid input file!"); }
            Plateau = new Plateau { Width = int.Parse(fo.CurrentFile.First().Split(" ")[0]), Height = int.Parse(fo.CurrentFile.First().Split(" ")[1]) };
           
            for (int i = 2; i < fo.CurrentFile.Count; i = i + 2)//process lines 2 by 2
            {
                var rover = new Rover();
                var arr = fo.CurrentFile[i - 1].Trim().Split();
                rover.Latitude = int.Parse(arr[0]);
                rover.Longitude = int.Parse(arr[1]);
                rover.CurrentDirection = (Direction)Enum.Parse(typeof(Direction), arr[2]);
                rover.RouteInstruction = fo.CurrentFile[i].Trim();
                rover.CurrentPlateau = Plateau;
                RoverList.Add(rover);
            }
            return this;
        }

        public void Operate()
        {
            foreach (var item in RoverList)
            {
                if (!item.FollowRoute())
                {
                    break;
                }
            }
        }
       
    }
}
