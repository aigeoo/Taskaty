using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;

namespace Taskaty.Services.TaskCommands
{
    internal class MarkedTaskAsDoneCommand : ICommand
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

                task.Status = '\u2705';
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("\nGreate Progress, Keep that energy \U0001F525\n");
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
