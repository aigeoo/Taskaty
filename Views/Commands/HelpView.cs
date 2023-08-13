using System;

namespace Taskaty.Views.Commands
{
    public class HelpView
    {
        public HelpView()
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

            Console.WriteLine("  Usage: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tTaskaty.exe [OPTIONS] ...\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Available options: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t--help            \tDisplay help for the list of commands");
                Console.WriteLine("\t--create          \tAdd a new task");
                Console.WriteLine("\t--read   <id>     \tDisplay detailed information about a specific task");
                Console.WriteLine("\t--done   <id>     \tMark a task as completed");
                Console.WriteLine("\t--update <id>     \tModify task information");
                Console.WriteLine("\t--list            \tDisplay information for all tasks");
                Console.WriteLine("\t--desc            \tSorts all tasks in descending");
                Console.WriteLine("\t--delete <id>     \tDelete a single task");

            Console.ResetColor();
        }
    }
}
