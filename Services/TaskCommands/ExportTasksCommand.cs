using System;
using Taskaty.Exceptions;
using Taskaty.Services.Interfaces;
using Taskaty.Views.helpers;
using Taskaty.Handlers;

namespace Taskaty.Services.TaskCommands
{
    internal class ExportTasksCommand : ICommand
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

                switch(id)
                {
                    case 1:
                        TasksExportingHandler.ExportMarkdown(tasks);
                        break;
                    case 2:
                        TasksExportingHandler.ExportHTML(tasks);
                        break;
                    default:
                        throw new Exception("Something went wrong.");
                }
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
            catch(Exception ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}