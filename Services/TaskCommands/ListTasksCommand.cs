using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Tables;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;

namespace Taskaty.Services.TaskCommands
{
    internal class ListTasksCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            try
            {
                List<Models.Task> tasks = context.Tasks.ToList();
                
                if (tasks == null)
                {
                    throw new TaskNotFoundException("There are no tasks yet.");
                }

                TasksView.Show(tasks);
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
