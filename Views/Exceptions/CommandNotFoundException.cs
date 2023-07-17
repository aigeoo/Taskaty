using System;

namespace Taskaty.Views.Exceptions
{
    class CommandNotFoundException
    {
        public static void Show(string command)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n   Command \"" + command + "\" is not defined");
            Console.ResetColor();
        }
    }
}
