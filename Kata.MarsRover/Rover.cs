﻿using System.Collections.Generic;
using Kata.MarsRover.RoverCommands;

namespace Kata.MarsRover
{
    public class Rover
    { 
        private readonly Grid grid;
        private Direction direction = Direction.North;
        private Coordinate coordinate = Coordinate.CreateInstance(0, 0);
        private IEnumerable<RoverCommand> commandList = new RoverCommand[0];

        public string ActualPosition => $"{coordinate.X}:{coordinate.Y}:{direction.Value}";

        public Rover(Grid grid)
        {
            this.grid = grid;
        }

        public void ExecuteCommands()
        {
            foreach (var command in commandList) 
                command.Execute();
        }

        public void SetCommands(string commands)
        {
            commandList = RoverCommandFactory.BuildFor(this, commands);
        }

        public void RotateRight() => direction = direction.RotateRight();
        public void RotateLeft() => direction = direction.RotateLeft();
        public void Move() => coordinate = grid.TryToMoveFor(coordinate, direction);
    }
}