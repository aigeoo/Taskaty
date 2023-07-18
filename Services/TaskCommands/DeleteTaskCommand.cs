using System;
using System.Collections.Generic;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Exceptions;

namespace Taskaty.Services.TaskCommands
{
    internal class DeleteTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            Models.Task? task = context.Tasks.Find(int.Parse(arg));

            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }
    }
}
