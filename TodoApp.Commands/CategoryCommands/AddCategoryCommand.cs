using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.CategoryCommands
{
    public class AddCategoryCommand: Command<AddCategoryRequest, AddCategoryResponse>, ICommand
    {
    }
}
