using System.Collections.Generic;
using System.Linq;

namespace Kata.MarsRover.RoverCommands
{
    public class RoverCommandFactory
    {
        private readonly Dictionary<char, RoverCommand> commandsByCharacter;

        public RoverCommandFactory(Rover rover)
        {
            commandsByCharacter = new Dictionary<char, RoverCommand>
            {
                { 'R', new RotateRightCommand(rover) },
                { 'L', new RotateLeftCommand(rover) },
                { 'M', new MoveCommand(rover) },
            };
        }
        
        public IEnumerable<RoverCommand> CreateFrom(string commands)
        {
            var commandList= new List<RoverCommand>();
            foreach (var command in commands.ToCharArray())
            {
                if (commandsByCharacter.ContainsKey(command)) 
                    commandList.Add(commandsByCharacter[command]);
                else 
                    throw new UnrecognizedCommandException(command);
            }
            
            return commandList;
        }
    }
}