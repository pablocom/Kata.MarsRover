namespace Kata.MarsRover
{
    public class Rover
    {
        private Direction direction;

        public Rover()
        {
            direction = Direction.North;
        }

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
}