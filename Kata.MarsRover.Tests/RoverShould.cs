using Kata.MarsRover.RoverCommands;
using NUnit.Framework;

namespace Kata.MarsRover.Tests
{
    public class RoverShould
    {
        private Rover rover;

        [SetUp]
        public void Initialise()
        {
            rover = new Rover(new Grid());
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void RotateRight(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        public void RotateLeft(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }

        [TestCase("M", "0:1:N")]
        [TestCase("MMM", "0:3:N")]
        public void MoveUp(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("MMMMMMMMM", "0:9:N")]
        [TestCase("MMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMM", "0:1:N")]
        public void WrapFromTopToBottomWhenMovingNorth(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("RM", "1:0:E")]
        [TestCase("RMMM", "3:0:E")]
        public void MoveRight(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("RMMMMMMMMM", "9:0:E")]
        [TestCase("RMMMMMMMMMM", "0:0:E")]
        [TestCase("RMMMMMMMMMMM", "1:0:E")]
        public void WrapFromRightToLeftWhenMovingEast(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("LM", "9:0:W")]
        [TestCase("LMMMMM", "5:0:W")]
        public void MoveLeft(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("LLM", "0:9:S")]
        [TestCase("LLMMMMM", "0:5:S")]
        public void MoveSouth(string commands, string expectedPosition)
        {
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }
        
        [TestCase("MMMM", 0, 4,"0:3:N")]
        [TestCase("RMMMMMM", 3, 0,"2:0:E")]
        public void StopAtObstacle(string commands, int obstaclePositionX, int obstaclePositionY, string expectedPosition)
        {
            var obstacle = Coordinate.CreateInstance(obstaclePositionX, obstaclePositionY);
            var gridWithObstacle = new Grid(obstacle);
            rover = new Rover(gridWithObstacle);
            
            rover.Execute(commands);
            
            Assert.That(rover.ActualPosition, Is.EqualTo(expectedPosition));
        }

        [Test]
        public void ThrowsUnrecognizedCommandException()
        {
            var notRecognizedCommand = "W";
            
            var exception = Assert.Throws<UnrecognizedCommandException>(() =>
            {
                rover.Execute(notRecognizedCommand);
            });
            
            Assert.That(exception.Message, 
                Is.EqualTo($"Command of type {notRecognizedCommand} not recognized"));
        }
    }
}