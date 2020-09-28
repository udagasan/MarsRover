using System;
using System.Collections.Generic;
using System.Linq;

namespace Exception
{
    public class InvalidCharacterException : System.Exception
    {
        public InvalidCharacterException()
        {
        }

        public InvalidCharacterException(string message)
            : base(message)
        {
        }

        public InvalidCharacterException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }

}
