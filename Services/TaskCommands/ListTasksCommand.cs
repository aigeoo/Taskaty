using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Tables;

namespace Taskaty.Services.TaskCommands
{
    internal class ListTasksCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            List<Models.Task> tasks = context.Tasks.ToList();

            TasksView.Show(tasks);
        }
    }
}
