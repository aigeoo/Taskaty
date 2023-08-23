using System;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;
using Taskaty.Services.Interfaces;

namespace Taskaty.Services.TaskCommands
{
    internal class CleanCompletedTasksCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            try
            {
                IQueryable<Models.Task> tasksToDelete = context.Tasks.Where(task => task.Status == "done");

                if (tasksToDelete == null)
                {
                    throw new TaskNotFoundException("The completed tasks with ID were not found.");
                }

                context.Tasks.RemoveRange(tasksToDelete);
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("The completed tasks was deleted successfully.");
            }
            catch (TaskNotFoundException e)
            {
                ExceptionHandler.PrintError(e.Message);
            }
        }
    }
}
