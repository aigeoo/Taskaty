using Alba.CsConsoleFormat;
using System.Drawing;
using Taskaty.Exceptions;
using Taskaty.Views.helpers;
using static System.ConsoleColor;

namespace Taskaty.Views.Tables
{
    class SingleTaskView
    {
        public static void Show(Models.Task task)
        {
            try
            {
                if (task == null)
                {
                    throw new TaskNotFoundException("\nThe task is Invalid");
                }

                var headerThickness = new LineThickness(LineWidth.Single, LineWidth.Single);

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
                            GridLength.Auto,
                            GridLength.Auto
                       },
                       Children =
                       {
                           new Cell("  ID      ") { Color = Blue },
                           new Cell("  Status     ") { Color = Blue },
                           new Cell("  Title    ") { Color = Blue },
                           new Cell("  Description   ") { Color = Blue },
                           new Cell("  Deadline   ") { Color = Blue },
                           new Cell("  Created At ") { Color = Blue },
                           new Cell("  Updated At ") { Color = Blue },
                           new[]
                           {
                                new Cell("   " + task.Id.ToString()),
                                new Cell("   " + task.Status.ToString()),
                                new Cell("   " + task.Title),
                                new Cell("   " + task.Description),
                                new Cell("   " + task.Deadline),
                                new Cell("   " + task.CreatedAt.ToString()),
                                new Cell("   " + task.UpdatedAt.ToString())
                            }
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
