using System;

namespace Taskaty.Views.Commands
{
    public class HelpView
    {
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(@"
    $$$$$$$$\                      $$\                   $$\               
    \__$$  __|                     $$ |                  $$ |              
        $$ |    $$$$$$\   $$$$$$$\ $$ |  $$\  $$$$$$\  $$$$$$\   $$\   $$\ 
        $$ |    \____$$\ $$  _____|$$ | $$  | \____$$\ \_$$  _|  $$ |  $$ |
        $$ |    $$$$$$$ |\$$$$$$\  $$$$$$  /  $$$$$$$ |  $$ |    $$ |  $$ |
        $$ |   $$  __$$ | \____$$\ $$  _$$<  $$  __$$ |  $$ |$$\ $$ |  $$ |
        $$ |   \$$$$$$$ |$$$$$$$  |$$ | \$$\ \$$$$$$$ |  \$$$$  |\$$$$$$$ |
        \__|    \_______|\_______/ \__|  \__| \_______|   \____/  \____$$ |
                                                                 $$\   $$ |
                                                                 \$$$$$$  |
                                                                  \______/ ");
            Console.Write("\n\t\tTaskaty ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("version ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("1.0.0 \n\n");

            Console.WriteLine(" Usage: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   command [option] [arguments=<id>|<keyword>]\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Available commands: ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   -h, --help");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t\t\tDisplay help for the list command");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("   task ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t--add              \t\tAdd a new task");
                    Console.WriteLine("\t--details <id>     \t\tGet all information about the task");
                    Console.WriteLine("\t--done    <id>     \t\tMark the task with done");
                    Console.WriteLine("\t--update  <id>     \t\tUpdate the task information");
                    Console.WriteLine("\t--list             \t\tGet  all tasks information");
                    Console.WriteLine("\t--search  <keyword>\t\tsearch about a specific word in the tasks");
                    Console.WriteLine("\t--delete  <id>     \t\tDelete a single task");

            Console.ResetColor();
        }
    }
}
