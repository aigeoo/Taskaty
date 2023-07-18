using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskaty.Services.Interfaces;

namespace Taskaty.Services.TaskCommands
{
    internal class SearchTaskCommand : ICommand
    {
        public void Execute(AppDbContext context, string arg)
        {
            // 
        }
    }
}
