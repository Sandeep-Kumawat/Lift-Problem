using Lift.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lift.Entities
{
    public class Person
    {
        public event ButtonPressedForCallingTheLift ButtonPressed;
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public WaitingStatus waitingStatus { get; set; }

        public Direction DirectionToGoIn
        {
            get
            {
                return CurrentFloor > DestinationFloor ? Direction.GoingDown : Direction.GoingUp;
            }
        }
        public Person(int currentFloor,int destinationFloor)
        {
            this.CurrentFloor = currentFloor;
            this.DestinationFloor = destinationFloor;
            this.waitingStatus = WaitingStatus.Waiting;
        }
        public void PressButton()
        {
            this.ButtonPressed(this.DirectionToGoIn);
        }

    }
}
