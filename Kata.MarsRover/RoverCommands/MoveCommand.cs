namespace Kata.MarsRover.RoverCommands
{
    public class MoveCommand : RoverCommand
    {
        public MoveCommand(Rover rover) : base(rover)
        { }

        public override void Execute() => Rover.Move();
    }
}