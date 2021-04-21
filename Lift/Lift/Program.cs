using Lift.Entities;
using System;

namespace Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] rawInput = new int[][] {
                new int[0], //0
                new int[] {6, 5}, //1
                new int[] {4}, //2
                new int[0], //3
                new int[] {6, 1 , 5, 6}, //4
                new int[0], //5
                new int[] {7}, //6
                new int[0], //7
            };

            int liftCapacity = 5;

            Building building = new Building(liftCapacity, rawInput);
            building.Move();
        }
    }
    
}
