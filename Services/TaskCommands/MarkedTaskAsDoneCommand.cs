using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;

namespace Taskaty.Services.TaskCommands
{
    internal class MarkedTaskAsDoneCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            Models.Task? task = context.Tasks.Find(int.Parse(arg));
            if (task != null)
            {
                task.Status = '\u2705';
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();

                Console.WriteLine("\nGreate Progress, Keep that energy \U0001F525\n");
            }
        }
    }
}
