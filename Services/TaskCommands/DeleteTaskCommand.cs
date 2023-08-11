using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;

namespace Taskaty.Services.TaskCommands
{
    internal class DeleteTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            try
            {
                Models.Task? task = context.Tasks.Find(id);

                if (task == null)
                {
                    throw new TaskNotFoundException("\nThe task with ID " + id + " was not found.");
                }

                context.Tasks.Remove(task);
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("\nThe task was deleted successfully.");
            }
            catch (TaskNotFoundException e)
            {
                ExceptionHandler.PrintError(e.Message);
            }
        }
    }
}
