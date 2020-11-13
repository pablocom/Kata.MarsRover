namespace Kata.MarsRover
{
    public class Coordinate
    {
        public static Coordinate CreateInstance(int x, int y)
        {
            return new Coordinate(x, y);
        }

        public int X { get; }    
        public int Y { get; }

        private Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}