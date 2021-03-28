using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Commands.SigningCommands;
using TodoApp.Data.Entity;
using TodoApp.Models.BusinessModels;
using TodoApp.Core.Security;

namespace TodoApp.CommandHandlers.SigingCommandHandlers
{
    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly AppcentTodoContext _context;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(AppcentTodoContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }
        protected override Task<RegisterUserResponse> ProcessCommand(RegisterUserCommand command)
        {
            var response = new RegisterUserResponse();
            var entity = _mapper.Map<AcUser>(command.Data);
            entity.CreateDate = DateTime.Now;
            var user = _context.AcUsers.Where(e => e.UserName == entity.UserName);

            if (user.Count() > 0)
                throw new Exception("UserName is already in use");
            var email = _context.AcUsers.Where(e => e.Email == entity.Email);

            if (email.Count() > 0)
                throw new Exception("Email is already in use");

            var security = new SecurityHelper();

            var salt = security.HashCreate();
            var passwordHash = security.HashCreate(entity.Password, salt);

            entity.Password = passwordHash.Split('æ')[0];
            entity.Salt = passwordHash.Split('æ')[1];

            _context.AcUsers.Add(entity);
            var result = _context.SaveChanges();

            if (result == 0)
                throw new Exception("An error occured while inserting user to table.");

            return Task.FromResult(response);
        }
    }
}
