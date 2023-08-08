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
        public void Execute(AppDbContext context, string arg)
        {
            try
            {
                Models.Task? task = context.Tasks.Find(int.Parse(arg));

                if (task == null)
                {
                    throw new TaskNotFoundException("\nThe task with ID " + arg + " was not found.");
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
