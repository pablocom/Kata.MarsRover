namespace Kata.MarsRover.RoverCommands
{
    public abstract class RoverCommand
    {
        protected readonly Rover Rover;

        protected RoverCommand(Rover rover)
        {
            Rover = rover;
        }

        public abstract void Execute();
    }
}