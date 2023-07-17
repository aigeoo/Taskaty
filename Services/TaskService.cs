using Microsoft.EntityFrameworkCore;
using Taskaty.Views.Exceptions;
using Taskaty.Views.Tables;

namespace Taskaty.Services
{
    class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTask()
        {
            Models.Task task = new();

            Console.Write("Title: ");
            task.Title = Console.ReadLine();

            task.Status = "⏳";

            Console.Write("Description: ");
            task.Description = Console.ReadLine();

            Console.Write("Deadline: ");
            task.Deadline = Console.ReadLine();

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void ReadTask(int id)
        {
            Models.Task? task = _context.Tasks.Find(id);
            if (task != null)
            {
                SingleTaskView.Show(task);
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }

        public void GetTasks()
        {
            List<Models.Task> tasks = _context.Tasks.ToList();

            TasksView.Show(tasks);
        }

        public void UpdateTask(int id)
        {
            Models.Task? task = _context.Tasks.Find(id);

            if (task != null)
            {
                Console.WriteLine("Enter updated information for the task with ID " + id + ":");
                Console.Write("Title: ");
                var title = Console.ReadLine();
                task.Title = string.IsNullOrEmpty(title) ? task.Title : title;

                Console.Write("Description: ");
                var description = Console.ReadLine();
                task.Description = string.IsNullOrEmpty(description) ? task.Description : description;

                Console.Write("Status (type 'done' if task finish): ");
                var status = Console.ReadLine();
                task.Status = string.IsNullOrEmpty(status) || status != "done" ? task.Status : "✅";

                Console.Write("Deadline: ");
                var deadline = Console.ReadLine();
                task.Deadline = string.IsNullOrEmpty(deadline) ? task.Deadline : deadline;

                task.UpdatedAt = DateTime.Now;

                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();

                Console.WriteLine("Task updated successfully.\n\n");
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }

        public void MarkTaskAsDone(int id)
        {
            Models.Task? task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.Status = "✅";
                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();
            }
        } 

        public void SearchTasks(string keyword)
        {
            //
        }

        public void DeleteTask(int id)
        {
            Models.Task? task = _context.Tasks.Find(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            else
            {
                TaskNotFoundException.Show();
            }
        }
    }
}
