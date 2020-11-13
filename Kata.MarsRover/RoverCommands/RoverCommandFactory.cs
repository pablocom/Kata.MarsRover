using System;
using System.Collections.Generic;

namespace Kata.MarsRover.RoverCommands
{
    public static class RoverCommandFactory
    {
        public static IEnumerable<RoverCommand> BuildFor(Rover rover, string commands)
        {
            var commandList = new List<RoverCommand>();
            foreach (var command in commands.ToCharArray())
            {
                if (command == 'R') 
                    commandList.Add(new RotateRightCommand(rover));
                else if (command == 'L') 
                    commandList.Add(new RotateLeftCommand(rover));
                else if (command == 'M') 
                    commandList.Add(new MoveCommand(rover));
                else 
                    throw new UnrecognizedCommandException(command);
            }

            return commandList;
        }
    }

    public class UnrecognizedCommandException : Exception
    {
        public UnrecognizedCommandException(char command) 
            : base($"Command of type {command} not recognized")
        {
            
        }
    }
}