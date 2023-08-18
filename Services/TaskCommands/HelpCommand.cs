using System;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.Commands;

namespace Taskaty.Services.TaskCommands
{
    internal class HelpCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            _ = new HelpView();
        }
    }
}
