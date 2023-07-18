using System;
using Microsoft.EntityFrameworkCore;
using Taskaty.Models;

namespace Taskaty
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            var connectionString = "SERVER=localhost;DATABASE=taskaty;UID=root;PASSWORD=''";

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}