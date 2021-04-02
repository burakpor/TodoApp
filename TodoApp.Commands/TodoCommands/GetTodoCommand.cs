using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.TodoCommands
{
    public class GetTodoCommand : Command<GetTodoRequest, GetTodoResponse>, ICommand
    {
    }
}
