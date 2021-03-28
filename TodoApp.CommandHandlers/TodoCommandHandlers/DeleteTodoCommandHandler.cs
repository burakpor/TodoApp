using System;
using System.Threading.Tasks;
using TodoApp.Commands.TodoCommands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.TodoCommandHandlers
{
    public class DeleteTodoCommandHandler : CommandHandler<DeleteTodoCommand, DeleteTodoResponse>
    {
        protected override Task<DeleteTodoResponse> ProcessCommand(DeleteTodoCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
