using Alba.CsConsoleFormat;
using System;
using System.Collections.Generic;
using Taskaty.Exceptions;
using Taskaty.Services;
using Taskaty.Services.Interfaces;
using Taskaty.Views.Commands;
using Taskaty.Views.helpers;

namespace Taskaty.Handlers
{
    class TaskManagerHandler
    {
        private readonly Service service;
        private readonly string[] valueless_arguments = { "--list", "--create", "--help" };

        public TaskManagerHandler()
        {
            service = new TaskService();
        }

        public void ExecuteCommand(AppDbContext db, string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("\nUsage: Taskaty.exe [OPTIONS] ...\n");
                    Console.WriteLine("Type Taskaty.exe --help to see a list of all options.\n");

                    return;
                }

                string argument = args[0];
                int id;

                if (!service.GetCommands().TryGetValue(argument, out ICommand? command))
                {
                    throw new CommandNotFoundException("\nThere is no such option: " + argument);
                }

                if (valueless_arguments.Contains(argument))
                {
                    id = 0;
                }
                else
                {
                    if (args.Length < 2)
                    {
                        throw new InvalidInputValueException("\nThe option value must be provided.");
                    }

                    if (!int.TryParse(args[1], out id))
                    {
                        throw new InvalidInputValueException("\nThe option value must be an integer.");
                    }
                }

                command.Execute(db, id);

            }
            catch (CommandNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
            catch (InvalidInputValueException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
