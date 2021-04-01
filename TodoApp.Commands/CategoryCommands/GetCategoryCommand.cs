using TodoApp.Models.BusinessModels;

namespace TodoApp.Commands.CategoryCommands
{
    public class GetCategoryCommand : Command<GetCategoryRequest, GetCategoryResponse>, ICommand
    {
    }
}
