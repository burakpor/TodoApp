using TodoApp.Models.EntityModels;

namespace TodoApp.Models.BusinessModels
{
    public class AddCategoryRequest : RequestBase
    {
        public string Category { get; set; }
        public string UserName { get; set; }
    }
}
