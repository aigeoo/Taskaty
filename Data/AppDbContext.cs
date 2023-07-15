using System;
using Microsoft.EntityFrameworkCore;

namespace Taskaty
{
    class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=taskaty;UID=root;PASSWORD=''");
    }
}