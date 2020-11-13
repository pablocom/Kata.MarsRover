namespace Kata.MarsRover
{
    public class Rover
    { 
        private readonly Grid grid;
        private Direction direction = Direction.North;
        private Coordinate coordinate = Coordinate.CreateInstance(0, 0);

        public string ActualPosition => $"{coordinate.X}:{coordinate.Y}:{direction.Value}";

        public Rover(Grid grid)
        {
            this.grid = grid;
        }

        public void Execute(string commands)
        {
            foreach (var command in commands.ToCharArray())
            {
                if (command == 'R') 
                    direction = direction.Right();
                if (command == 'L') 
                    direction = direction.Left();
                if (command == 'M')
                {
                    coordinate = grid.TryToMoveFor(coordinate, direction);
                }
            }
        }
    }
}