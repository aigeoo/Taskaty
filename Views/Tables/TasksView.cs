using Alba.CsConsoleFormat;
using Taskaty.Views.Exceptions;
using static System.ConsoleColor;

namespace Taskaty.Views.Tables
{
    class TasksView
    {
        public static void Show(List<Models.Task> tasks)
        {
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
                          GridLength.Auto,
                          GridLength.Auto
                      },
                      Children =
                      {
                          new Cell("ID") { Stroke = headerThickness, Color = Blue },
                          new Cell("Status") { Stroke = headerThickness, Color = Blue },
                          new Cell("Title") { Stroke = headerThickness, Color = Blue },
                          new Cell("Description") { Stroke = headerThickness, Color = Blue },
                          new Cell("Deadline") { Stroke = headerThickness, Color = Blue },
                          new Cell("Created At") { Stroke = headerThickness , Color = Blue},
                          new Cell("Updated At") { Stroke = headerThickness , Color = Blue},
                          tasks.ConvertAll(task => new[]
                          {
                              new Cell(task.Id.ToString()),
                              new Cell(task.Status),
                              new Cell(task.Title),
                              new Cell(task.Description),
                              new Cell(task.Deadline),
                              new Cell(task.CreatedAt.ToString()),
                              new Cell(task.UpdatedAt.ToString())
                          })
                      }
                  }
              );

              ConsoleRenderer.RenderDocument(doc);
              Console.WriteLine();
        }
    }
}
