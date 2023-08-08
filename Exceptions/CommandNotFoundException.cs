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
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("\n   Command \"" + command + "\" is not defined");
            //Console.ResetColor();
        }

        public CommandNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}