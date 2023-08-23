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
                    throw new TaskNotFoundException("The task is Invalid");
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
                           new Cell("  ID         ") { Color = Blue },
                           new Cell("  Status     ") { Color = Blue },
                           new Cell("  Title      ") { Color = Blue },
                           new Cell("  Note       ") { Color = Blue },
                           new Cell("  Due        ") { Color = Blue },
                           new Cell("  Created At ") { Color = Blue },
                           new Cell("  Updated At ") { Color = Blue },
                           new[]
                           {
                                new Cell("   " + task.Id.ToString()),
                                new Cell("   " + task.Status),
                                new Cell("   " + task.Title),
                                new Cell("   " + task.Note),
                                new Cell("   " + task.Due),
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
