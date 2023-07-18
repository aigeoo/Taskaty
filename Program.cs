using System;
using Taskaty.Handlers;

namespace Taskaty
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext db = new AppDbContext();

            TaskManagerHandler taskManager = new TaskManagerHandler();
            taskManager.ExecuteCommand(db, args);
        }
    }
}