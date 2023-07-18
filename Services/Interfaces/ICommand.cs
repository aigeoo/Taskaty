using System;
using System.Collections.Generic;

namespace Taskaty.Services.Interfaces
{
    internal interface ICommand
    {
        void Execute(AppDbContext context, string arg);
    }
}
