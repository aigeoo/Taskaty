using System;
using Taskaty.Handlers;

namespace Taskaty
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new();

            TaskManagerHandler taskManager = new();
            taskManager.ExecuteCommand(db, args);
        }
    }
}