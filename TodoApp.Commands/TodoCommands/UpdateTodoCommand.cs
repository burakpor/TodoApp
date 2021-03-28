using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.TodoCommands
{
    public class UpdateTodoCommand : Command<UpdateTodoRequest, UpdateTodoResponse>, ICommand
    {
    }
}
