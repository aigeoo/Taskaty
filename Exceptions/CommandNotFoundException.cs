using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Taskaty.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException()
        {
        }
        public CommandNotFoundException(string message)
            : base(message)
        {
        }

        public CommandNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}