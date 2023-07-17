using System;

namespace Taskaty.Views.Exceptions
{
    class InvalidInputValueException
    {
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n   The input value is invalid");
            Console.ResetColor();
        }
    }
}
