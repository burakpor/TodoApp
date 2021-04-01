using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : Command<DeleteCategoryRequest, DeleteCategoryResponse>, ICommand
    {
    }
}
