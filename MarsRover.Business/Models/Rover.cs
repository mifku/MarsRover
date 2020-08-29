using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business
{
    public class Rover
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string RouteInstruction { get; set; }
        public Direction CurrentDirection { get; set; }
        public Plateau CurrentPlateau{ get; set; }
        public Rover()
        {

        }
        public Rover(int lat, int longi, string route , Plateau plateau, char direction)
        {
            Latitude = lat;
            Longitude = longi;
            RouteInstruction = route;
            CurrentPlateau = plateau;
            CurrentDirection = (Direction)Enum.Parse(typeof(Direction), direction.ToString());
        }
        private void TurnLeft()
        {
            //in modular operations you can minus result by adding (m-1) to result 
            //so here to get -1 just add (4-1) and get mod. also you never get negative values
            CurrentDirection = (Direction)(((int)CurrentDirection + 3) %4);  
        }

        private void TurnRight()
        {
            CurrentDirection = (Direction)(((int)CurrentDirection + 1) %4);  //N->E->S->W->N
        }

        private void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.N:
                    Longitude++;
                    break;
                case Direction.E:
                    Latitude++;
                    break;
                case Direction.S:
                    Longitude--;
                    break;
                case Direction.W:
                    Latitude--;
                    break;
                default:
                    break;
            }
        }

        public bool FollowRoute()
        {
            foreach (var instruction in RouteInstruction)
            {
                switch (instruction)
                {
                    case (char)Command.Left:
                        TurnLeft();
                        break;
                    case (char)Command.Right:
                        TurnRight();
                        break;
                    case (char)Command.Move:
                        Move();
                        break;
                    default:
                        Console.WriteLine($"Invalid Command! Action is stopped. Recent location {Latitude} {Longitude} {CurrentDirection.ToString()}"); //Stopping action is up to your preference,this case didnt mentioned on document
                        return false;                        
                }

                if (!IsInRange())
                {
                    Console.WriteLine($"Rover got out of plateau range! Action is stopped. Recent location {Latitude} {Longitude} {CurrentDirection.ToString()}"); //Stopping action is up to your preference,this case didnt mentioned on document
                    return false;
                }
            }
            Console.WriteLine($"{Latitude} {Longitude} {CurrentDirection.ToString()}");
            return true;
        }

        private bool IsInRange()
        {
            return (Longitude >= 0 && Latitude >= 0 && Longitude <= CurrentPlateau.Height && Latitude <= CurrentPlateau.Width);
        }

    }

   
   
}
