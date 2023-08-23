using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;
using Taskaty.Views.Tables;

namespace Taskaty.Services.TaskCommands
{
    internal class ReadTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            try
            {
                Models.Task? task = context.Tasks.Find(id);

                if (task == null)
                {
                    throw new TaskNotFoundException("The task with ID " + id + " was not found.");
                }

                SingleTaskView.Show(task);
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
