using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata.MarsRover
{
    public class Rover
    {
        private Direction direction = Direction.North;

        public string Execute(string commands)
        {
            foreach (var command in commands.ToCharArray())
            {
                if (command == 'R')
                    direction = direction.Right();
                if (command == 'L')
                    direction = direction.Left();
            }

            return $"0:0:{direction.Value}";
        }
    }
    
    public class Direction 
    {
        public static readonly Direction North = new Direction("N", "W", "E");
        public static readonly Direction East = new Direction("E", "N", "S");
        public static readonly Direction South = new Direction("S", "E", "W");
        public static readonly Direction West = new Direction("W", "S", "N");
        
        private static readonly IEnumerable<Direction> AllDirections = new List<Direction>
        {
            North, East, South, West
        };
        
        public string Value { get; }
        private readonly string leftValue;
        private readonly string rightValue;

        private Direction(string value, string leftValue, string rightValue)
        {
            this.Value = value;
            this.leftValue = leftValue;
            this.rightValue = rightValue;
        }

        public Direction Right() => AllDirections.First(direction => direction.Value == this.rightValue);
        public Direction Left() => AllDirections.First(direction => direction.Value == this.leftValue);
    }
}