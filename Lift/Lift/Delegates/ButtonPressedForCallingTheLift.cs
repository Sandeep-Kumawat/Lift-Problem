using Lift.Entities;
using Lift.Enums;
using System.Collections.Generic;

public delegate void ButtonPressedForCallingTheLift(Direction direction);
public delegate void ButtonPressedForCallingTheLiftOnAGivenFloor(Direction direction, int callingFloor,List<Person> PeopleWaitingForLift);