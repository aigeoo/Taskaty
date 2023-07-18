using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Exceptions;
using Taskaty.Views.Tables;

namespace Taskaty.Services.TaskCommands
{
    internal class ReadTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            Models.Task? task = context.Tasks.Find(int.Parse(arg));
            if (task != null)
            {
                SingleTaskView.Show(task);
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }
    }
}
