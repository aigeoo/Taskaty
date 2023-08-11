using System;
using Taskaty.Services.Interfaces;

namespace Taskaty.Services
{
    abstract class Service
    {
        public abstract Dictionary<string, ICommand> GetCommands();
    }
}
