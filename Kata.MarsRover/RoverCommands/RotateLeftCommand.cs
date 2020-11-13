namespace Kata.MarsRover.RoverCommands
{
    public class RotateLeftCommand : RoverCommand
    {
        public RotateLeftCommand(Rover rover) : base(rover)
        { }

        public override void Execute() => Rover.RotateLeft();
    }
}