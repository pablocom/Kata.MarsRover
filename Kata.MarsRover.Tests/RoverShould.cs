using NUnit.Framework;

namespace Kata.MarsRover.Tests
{
    public class RoverShould
    {
        private Rover rover;

        [SetUp]
        public void Initialise()
        {
            rover = new Rover();
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void RotateRight(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        public void RotateLeft(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }

        [TestCase("M", "0:1:N")]
        [TestCase("MMM", "0:3:N")]
        public void MoveUp(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("MMMMMMMMM", "0:9:N")]
        [TestCase("MMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMM", "0:1:N")]
        public void WrapFromTopToBottomWhenMovingNorth(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("RM", "1:0:E")]
        [TestCase("RMMM", "3:0:E")]
        public void MoveRight(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("RMMMMMMMMM", "9:0:E")]
        [TestCase("RMMMMMMMMMM", "0:0:E")]
        [TestCase("RMMMMMMMMMMM", "1:0:E")]
        public void WrapFromRightToLeftWhenMovingEast(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("LM", "9:0:W")]
        [TestCase("LMMMMM", "5:0:W")]
        public void MoveLeft(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("LLM", "0:9:S")]
        [TestCase("LLMMMMM", "0:5:S")]
        public void MoveSouth(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
    }
}