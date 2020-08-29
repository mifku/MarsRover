using MarsRover.Business;
using MarsRover.Business.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                MarsOperator marsOperator = new MarsOperator();
                marsOperator.BuildSetup().Operate();
                Console.Read();
            }
            catch (Exception ex)
            {

                Console.WriteLine("An exception occured  :  "+ex.Message);
                Console.Read();
            }
           
        }
    }
}
