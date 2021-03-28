using System;
using System.Threading.Tasks;
using TodoApp.Commands.TodoCommands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.TodoCommandHandlers
{
    public class GetTodoCommandHandler : CommandHandler<GetTodoCommand, GetTodoResponse>
    {
        protected override Task<GetTodoResponse> ProcessCommand(GetTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
