using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TodoApp.Commands.CategoryCommands;
using TodoApp.Commands.TodoCommands;
using TodoApp.Data.Entity;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.CategoryCommandHandlers
{
    public class AddCategoryCommandHandler : CommandHandler<AddCategoryCommand, AddCategoryResponse>
    {
        private readonly AppcentTodoContext _context;
        public AddCategoryCommandHandler(AppcentTodoContext context)
        {
            _context = context;
        }
        protected override Task<AddCategoryResponse> ProcessCommand(AddCategoryCommand command)
        {
            var response = new AddCategoryResponse();
            var request = command.Data;
            var user = _context.AcUsers.FirstOrDefault(e => e.UserName == request.UserName);

            var category = new AcCategory
            {
                CategoryName = request.Name,
                User = user,
                IsDeleted = false
            };

            _context.AcCategories.Add(category);
            var result  =_context.SaveChanges();
            if(result > 0)
            {
                response.CategoryId = category.CategoryId;
            }
            else
            {
                throw new Exception("An error occur while adding category.");
            }


            return Task.FromResult(response);
        }
    }
}
