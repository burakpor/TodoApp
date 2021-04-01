namespace TodoApp.Models.BusinessModels
{
    public class DeleteCategoryRequest : RequestBase
    {
        public int CategoryId { get; set; }
        public string UserName { get; set; }
    }
}
