using System.Linq;
using System.Threading.Tasks;
using TodoApp.Commands.SigningCommands;
using TodoApp.Data;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.SigingCommandHandlers
{
    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly AppcentTodoContext context;
        public RegisterUserCommandHandler(AppcentTodoContext _context) {
            context = _context;
        }
        protected override Task<RegisterUserResponse> ProcessCommand(RegisterUserCommand command)
        {
            if (command != null)
            {
                var a = context.TestTables.FirstOrDefault(x => x.Id == 1)?.Id;
                var test = command.Data;
            }

            return Task.FromResult(new RegisterUserResponse { Result= new ResultModel {IsSuccess = true } });
        }
    }
}
