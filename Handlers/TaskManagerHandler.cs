using System;
using System.Collections.Generic;
using Taskaty.Services;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Commands;

namespace Taskaty.Handlers
{
    class TaskManagerHandler
    {
        private readonly Dictionary<string, Service> services;

        public TaskManagerHandler()
        {
            services = new Dictionary<string, Service>
            {
                { "task", new TaskService() },
            };
        }

        public void ExecuteCommand(AppDbContext db, string[] args)
        {
            if (args.Length < 3)
            {
                HelpView.Show();
                return;
            }

            string serviceName = args[0];
            string commandName = args[1];
            string commandArg = "null";

            if (!String.IsNullOrEmpty(args[2]))
            {
                commandArg = args[2];
            }

            if (services.TryGetValue(serviceName, out Service? service))
            {
                if (service.GetCommands().TryGetValue(commandName, out ICommand? command))
                {
                    command.Execute(db, commandArg);
                }
                else
                {
                    Console.WriteLine("Unknown command: " + commandName);
                }
            }
        }
    }
}
