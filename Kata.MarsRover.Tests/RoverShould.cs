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
        public void RotatesRight(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
        
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        public void RotatesLeft(string command, string expectedPosition)
        {
            Assert.That(rover.Execute(command), Is.EqualTo(expectedPosition));
        }
    }
}