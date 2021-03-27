using System.Threading.Tasks;
using TodoApp.Commands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler 
        where TCommand: ICommand
        where TResult : ICommandResult
    {
        protected abstract Task<TResult> ProcessCommand(TCommand command);
        public virtual async Task<ICommandResult> Execute(ICommand command)
        {
            return await ProcessCommand((TCommand)command);
        }
    }
}
