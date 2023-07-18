using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;

namespace Taskaty.Services.TaskCommands
{
    internal class CreateTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            Models.Task task = new();

            Console.Write("Title: ");
            task.Title = Console.ReadLine();

            Console.Write("Description: ");
            task.Description = Console.ReadLine();

            Console.Write("Deadline: ");
            task.Deadline = Console.ReadLine();

            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}
