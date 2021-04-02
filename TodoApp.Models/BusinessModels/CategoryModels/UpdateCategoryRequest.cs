using TodoApp.Models.EntityModels;

namespace TodoApp.Models.BusinessModels
{
    public class UpdateCategoryRequest : RequestBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

    }
}
