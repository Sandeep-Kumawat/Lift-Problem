using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lift.Entities
{
    public class Floor
    {
        public event ButtonPressedForCallingTheLiftOnAGivenFloor ButtonPressedForCallingTheLift;
        public int FloorNumber { get; set; }

        public List<Person> PeopleWaitingForLift { get; set; }

        public List<Person> PeopleBelongToTheFloor { get; set; }

        public Floor(int floorNumber,int[] floorNumbersPeopleWantToGoTo)
        {
            this.FloorNumber = floorNumber;
            this.PeopleWaitingForLift = floorNumbersPeopleWantToGoTo.Select(floorNumbersPeopleWantToGoTo =>
            {
                var person = new Person(floorNumber, floorNumbersPeopleWantToGoTo);
                person.ButtonPressed += this.ButtonPress;
                return person;
            }).ToList();

        }

        public void ButtonPress( Direction direction)
        {
            this.ButtonPressedForCallingTheLift(direction, this.FloorNumber,this.PeopleWaitingForLift);
        }

    }
}
