using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.TodoCommands
{
    public class AddTodoCommand: Command<RegisterUserRequest,RegisterUserResponse>, ICommand
    {
    }
}
