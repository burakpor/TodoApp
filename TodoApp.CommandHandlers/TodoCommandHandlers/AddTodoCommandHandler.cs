using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TodoApp.Commands.TodoCommands;
using TodoApp.Data.Entity;
using TodoApp.Models.BusinessModels;

namespace TodoApp.CommandHandlers.TodoCommandHandlers
{
    public class AddTodoCommandHandler : CommandHandler<AddTodoCommand, AddTodoResponse>
    {
        private readonly AppcentTodoContext _context;
        public AddTodoCommandHandler(AppcentTodoContext context)
        {
            _context = context;
        }
        protected override Task<AddTodoResponse> ProcessCommand(AddTodoCommand command)
        {
            var response = new AddTodoResponse();
            var request = command.Data;
            var user = _context.AcUsers.FirstOrDefault(e => e.UserName == request.UserName);

            var category = _context.AcCategories.FirstOrDefault(e => e.UserId == user.UserId && e.CategoryId == request.CategoryId && e.IsDeleted == false);
            if (category != null)
            {
                var entity = new AcTask
                {
                    Name = command.Data.Name,
                    Category = category,
                    User = user,
                    RootTaskId = request.RootTaskId == 0 ? null : request.RootTaskId,
                    Status = (short)request.TaskStatus,
                    TaskPriorityId = (short)request.TaskPriority,
                    CreateDate = DateTime.Now
                };

                using (var scope = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.AcTasks.Add(entity);
                        var activity = new AcTaskActivity
                        {
                            Activity = "Task Create",
                            ActivityDate = DateTime.Now,
                            Task = entity
                        };
                        _context.Add(activity);
                        _context.SaveChanges();
                        scope.Commit();
                    }
                    catch(Exception ex)
                    {
                        scope.Rollback();
                        throw new Exception("An error occured while creating task.");
                    }
                }
                response.TaskId = entity.TaskId;
            }
            else
            {
                throw new Exception("An error occured while creating task.");
            }

            return Task.FromResult(response);
        }
    }
}
