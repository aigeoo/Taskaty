using System;
using Taskaty.Services.Interfaces;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;


namespace Taskaty.Services.TaskCommands
{
    internal class CreateTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, int id)
        {
            try
            {
                Models.Task task = new();

                Console.Write("\nTitle: ");
                task.Title = Console.ReadLine()!.Trim();

                Console.Write("\nNote: ");
                task.Note = Console.ReadLine()!.Trim();

                Console.Write("\nDue: ");
                task.Due = Console.ReadLine()!.Trim();

                if (string.IsNullOrEmpty(task.Title) ||
                    string.IsNullOrEmpty(task.Note) ||
                    string.IsNullOrEmpty(task.Due))
                {
                    throw new InvalidInputValueException("Fields should be of type string and must not be empty.");
                }

                context.Tasks.Add(task);
                context.SaveChanges();

                ExceptionHandler.PrintSuccess("New task was created successfully.");
            }
            catch (InvalidInputValueException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
