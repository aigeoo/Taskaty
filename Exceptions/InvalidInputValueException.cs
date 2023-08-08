using System;

namespace Taskaty.Exceptions
{
    class InvalidInputValueException : Exception
    {
        public InvalidInputValueException()
        {
        }

        public InvalidInputValueException(string message)
            : base(message)
        {
        }

        public InvalidInputValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
