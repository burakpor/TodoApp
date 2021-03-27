using System.Threading.Tasks;
using TodoApp.Commands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers
{
    public interface ICommandHandler
    {
        Task<ICommandResult> Execute(ICommand command);
    }
}
