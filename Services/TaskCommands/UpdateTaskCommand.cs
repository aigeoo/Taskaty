using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;

namespace Taskaty.Services.TaskCommands
{
    internal class UpdateTaskCommand : ICommand
    {
        private Models.Task? updatedTask;

        public void Execute(AppDbContext context, int id)
        {
            try
            {
                Models.Task? task = context.Tasks.Find(id);

                if (task == null)
                {
                    throw new TaskNotFoundException("\nThe task with ID " + id + " was not found.");
                }

                updatedTask = UpdatingWizard(id, task);

                context.Entry(updatedTask).State = EntityState.Modified;
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("\nTask updated successfully.");
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }

        private Models.Task UpdatingWizard(int id, Models.Task task)
        {
            Console.WriteLine("Enter updated information for the task with ID " + id + ":");
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

            return task;
        }
    }
}
