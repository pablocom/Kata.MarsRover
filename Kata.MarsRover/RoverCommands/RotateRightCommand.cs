namespace Kata.MarsRover.RoverCommands
{
    public class RotateRightCommand : RoverCommand
    {
        public RotateRightCommand(Rover rover) : base(rover)
        { }
        
        public override void Execute() => Rover.RotateRight();
    }
}