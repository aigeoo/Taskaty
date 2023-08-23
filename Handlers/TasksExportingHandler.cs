using System;
using System.Text;

namespace Taskaty.Handlers
{
    internal class TasksExportingHandler
    {
        public static void ExportHTML(List<Models.Task> tasks)
        {
            string content = "<!DOCTYPE html>\n" +
                "<html>\n" +
                "<head>\n" +
                "  <title>Task List</title>\n" +
                "</head>\n" +
                "<body>\n" +
                "  <ul>\n";

            foreach (var task in tasks)
            {
                string taskHtml = $@"    <li>
      <label><input type=""checkbox""> {task.Title}</label>
      <ul>
        <li>Due: {task.Due}</li>
        <li>Status: {task.Status}</li>
        <li>Notes: {task.Note}.</li>
      </ul>
    </li>";
                content += taskHtml + "\n";
            }

            content += "  </ul>\n" +
                           "</body>\n" +
                           "</html>";

            string fileName = "Taskaty.html";
            File.WriteAllText(fileName, content);
        }

        public static void ExportMarkdown(List<Models.Task> tasks)
        {
            string content = "";

            foreach (var task in tasks)
            {
                string taskMarkdown = $@"- [ ] {task.Title}
   - Due: {task.Due}
   - Status: {task.Status}
   - Notes: {task.Note}
";
                content += taskMarkdown;
            }

            string fileName = "Taskaty.md";
            File.WriteAllText(fileName, content);
        }
    }
}
