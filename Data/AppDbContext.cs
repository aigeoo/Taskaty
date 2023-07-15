using System;
using Microsoft.EntityFrameworkCore;
using Taskaty.Models;

namespace Taskaty
{
    class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            var connectionString = "SERVER=localhost;DATABASE=taskaty;UID=root;PASSWORD=''";

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}