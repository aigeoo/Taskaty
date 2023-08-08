using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;

namespace Taskaty.Services.TaskCommands
{
    internal class DeleteTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            try
            {
                Models.Task? task = context.Tasks.Find(int.Parse(arg));

                if (task == null)
                {
                    throw new TaskNotFoundException("\nThe task with ID " + arg + " was not found.");
                }

                context.Tasks.Remove(task);
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("\n The task was deleted successfully.");
            }
            catch (TaskNotFoundException e)
            {
                ExceptionHandler.PrintError(e.Message);
            }
        }
    }
}
