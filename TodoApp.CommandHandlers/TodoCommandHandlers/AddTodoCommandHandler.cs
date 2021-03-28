using System;
using System.Threading.Tasks;
using TodoApp.Commands.TodoCommands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.TodoCommandHandlers
{
    public class AddTodoCommandHandler : CommandHandler<AddTodoCommand, UserLoginResponse>
    {
        protected override Task<UserLoginResponse> ProcessCommand(AddTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
