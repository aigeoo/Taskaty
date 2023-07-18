using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Exceptions;

namespace Taskaty.Services.TaskCommands
{
    internal class UpdateTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            Models.Task? task = context.Tasks.Find(int.Parse(arg));

            if (task != null)
            {
                Console.WriteLine("Enter updated information for the task with ID " + arg + ":");
                Console.Write("Title: ");
                var title = Console.ReadLine();
                task.Title = string.IsNullOrEmpty(title) ? task.Title : title;

                Console.Write("Description: ");
                var description = Console.ReadLine();
                task.Description = string.IsNullOrEmpty(description) ? task.Description : description;

                Console.Write("Status (type 'done' if task finish): ");
                var status = Console.ReadLine();
                task.Status = string.IsNullOrEmpty(status) || status != "done" ? task.Status : '\u2714';

                Console.Write("Deadline: ");
                var deadline = Console.ReadLine();
                task.Deadline = string.IsNullOrEmpty(deadline) ? task.Deadline : deadline;
                task.UpdatedAt = DateTime.Now;

                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();

                Console.WriteLine("Task updated successfully.\n\n");
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }
    }
}
