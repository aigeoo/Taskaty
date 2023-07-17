using System;

namespace Taskaty.Views.Exceptions
{
    class TaskNotFoundException
    {
        public static void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n   Task not found");
            Console.ResetColor();
        }
    }
}
