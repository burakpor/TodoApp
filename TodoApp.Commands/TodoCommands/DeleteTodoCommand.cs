using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.TodoCommands
{
    public class DeleteTodoCommand : Command<DeleteTodoRequest, DeleteTodoResponse>, ICommand
    {
    }
}
