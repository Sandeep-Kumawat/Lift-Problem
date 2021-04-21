using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift.Entities
{
    public class Building
    {
        public Floor[] Floors { get; set; }

        public Lift Lift { get; set; }

      public Building(int liftCapacity, int[][] floorAndPeopleComposition)
        {
            Floors = floorAndPeopleComposition.Select((floorComposition, floorNumber) =>
             {
                 var floor = new Floor(floorNumber, floorComposition);
                 floor.ButtonPressedForCallingTheLift += this.LiftRequested;
                 return floor;
             }).ToArray();
            this.Lift = new Lift(liftCapacity,this.Floors.Length-1);
        }
        public void Move()
        {
            //Console.WriteLine(this.Lift.CurrentFloor);
            foreach(Floor floor in Floors)
            {
                //if(floor.PeopleWaitingForLift.Count()>0)
                //{
                //    floor.PeopleWaitingForLift.First().PressButton();
                //}
                floor.PeopleWaitingForLift.ForEach(p =>
                {
                    while (p.waitingStatus == WaitingStatus.Waiting)
                    {
                        p.PressButton();
                    }
                });
            }
            this.Lift.MoveToTop();
            this.Lift.MoveToGround();
            Console.WriteLine($"Stopped On:{this.Lift.CurrentFloor}");
        }
        public void LiftRequested(Direction direction,int floorNumberRequestedOn, List<Person> PeopleWaiting)
        {
            Console.WriteLine($"Stopped On:{this.Lift.CurrentFloor}");
            this.Lift.LiftStart(direction, floorNumberRequestedOn);
            PeopleWaiting.ForEach(person =>
            {
                if (person.DestinationFloor > this.Lift.CurrentFloor)
                {
                    person.waitingStatus = WaitingStatus.BoardedLift;
                    this.Lift.People.Add(person);
                }
                else if (person.DestinationFloor < this.Lift.CurrentFloor)
                {
                    person.waitingStatus = WaitingStatus.BoardedLift;
                    this.Lift.People.Add(person);
                }
            });

        }
    }
}
