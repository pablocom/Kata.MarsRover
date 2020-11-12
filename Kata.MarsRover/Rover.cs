namespace Kata.MarsRover
{
    public class Rover
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;
        
        private Direction direction = Direction.North;
        private Coordinate coordinate = new Coordinate(0, 0);

        public string Execute(string commands)
        {
            foreach (var command in commands.ToCharArray())
            {
                if (command == 'R') direction = direction.Right();
                if (command == 'L') direction = direction.Left();
                if (command == 'M') coordinate = Move();
            }

            return $"{coordinate.X}:{coordinate.Y}:{direction.Value}";
        }

        private Coordinate Move()
        {
            var y = coordinate.Y;
            var x = coordinate.X;
            
            if (direction == Direction.North)
                y = (y + 1) % MaxHeight;

            if (direction == Direction.East)
                x = (x + 1) % MaxWidth;

            if (direction == Direction.West)
                if (x > 0)
                    x -= 1;
                else
                    x = 9;

            if (direction == Direction.South)
                if (y > 0)
                    y -= 1;
                else
                    y = 9;

            return new Coordinate(x, y);
        }
    }
    public class Coordinate
    {
        public int X { get; }    
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoveUp() => this.Y++;
    }
}