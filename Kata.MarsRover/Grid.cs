using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata.MarsRover
{
    public class Grid
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;

        private IEnumerable<Coordinate> obstaclesCoordinates = new List<Coordinate>();
        
        public Grid()
        { }

        public Grid(params Coordinate[] obstaclesCoordinates)
        {
            this.obstaclesCoordinates = obstaclesCoordinates;
        }

        public Coordinate TryToMoveFor(Coordinate coordinate, Direction direction)
        {
            var newCoordinate = CalculatePotentialNextCoordinate(coordinate, direction);

            if (obstaclesCoordinates.Any(obstacleCoordinate => obstacleCoordinate.Equals(newCoordinate)))
                return coordinate;

            return newCoordinate;
        }

        private Coordinate CalculatePotentialNextCoordinate(Coordinate coordinate, Direction direction)
        {
            var y = coordinate.Y;
            var x = coordinate.X;
            
            if (direction == Direction.North)
                y = (y + 1) % MaxHeight;

            if (direction == Direction.East)
                x = (x + 1) % MaxWidth;

            if (direction == Direction.West)
            {
                if (x > 0) x -= 1;
                else x = 9;
            }
            if (direction == Direction.South)
            {
                if (y > 0) y -= 1;
                else y = 9;
            }

            return Coordinate.CreateInstance(x, y);
        }
    }
}