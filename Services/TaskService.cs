using Taskaty.Services.TaskCommands;
using Taskaty.Services.Interfaces;
using Taskaty.Services;

internal class TaskService : Service
{
    public override string ServiceName => "task";

    public override Dictionary<string, ICommand> GetCommands()
    {
        return new Dictionary<string, ICommand>
        {
            { "--create", new CreateTaskCommand() },
            { "--read", new ReadTaskCommand() },
            { "--update", new UpdateTaskCommand() },
            { "--delete", new DeleteTaskCommand() },
            { "--list", new ListTasksCommand() },
            { "--done", new MarkedTaskAsDoneCommand() },
            { "--search", new SearchTaskCommand() }
        };
    }
}