using Alba.CsConsoleFormat;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;
using static System.ConsoleColor;

namespace Taskaty.Views.Tables
{
    class TasksView
    {
        public static void Show(List<Models.Task> tasks)
        {
            try
            {
                if (tasks == null)
                {
                    throw new TaskNotFoundException("Tasks list is invalid");
                }

                var headerThickness = new LineThickness(LineWidth.Double, LineWidth.Single);

                var doc = new Document(
                    new Grid
                    {
                        Color = Gray,
                        Columns =
                        {
                          GridLength.Auto,
                          GridLength.Auto,
                          GridLength.Auto,
                          GridLength.Auto,
                          GridLength.Auto,
                        },
                        Children =
                        {
                          new Cell("  ID      ") { Color = Blue },
                          new Cell("  Status     ") { Color = Blue },
                          new Cell("  Title    ") { Color = Blue },
                          new Cell("  Note   ") { Color = Blue },
                          new Cell("  Due   ") { Color = Blue },
                          tasks.ConvertAll(task => new[]
                          {
                              new Cell("   " + task.Id.ToString()),
                              new Cell("   " + task.Status.ToString()),
                              new Cell("   " + task.Title),
                              new Cell("   " + task.Note),
                              new Cell("   " + task.Due),
                          })
                        }
                    }
                );

                ConsoleRenderer.RenderDocument(doc);
                Console.WriteLine();
            }
            catch (TaskNotFoundException ex)
            {
                ExceptionHandler.PrintError(ex.Message);
            }
        }
    }
}
