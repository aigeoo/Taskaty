using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Taskaty.Models;

namespace Taskaty
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;

            string dbPath = Path.Combine(Path.GetDirectoryName(assemblyLocation)!, "app.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}