using System;
using System.Threading.Tasks;
using TodoApp.Commands.TodoCommands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.TodoCommandHandlers
{
    public class UpdateTodoCommandHandler : CommandHandler<UpdateTodoCommand, UpdateTodoResponse>
    {
        protected override Task<UpdateTodoResponse> ProcessCommand(UpdateTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
