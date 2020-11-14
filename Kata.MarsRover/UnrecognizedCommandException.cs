using System;

namespace Kata.MarsRover
{
    public class UnrecognizedCommandException : Exception
    {
        public UnrecognizedCommandException(char command) 
            : base($"Command of type {command} not recognized")
        { }
    }
}