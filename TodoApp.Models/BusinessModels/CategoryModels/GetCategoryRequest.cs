namespace TodoApp.Models.BusinessModels
{
    public class GetCategoryRequest : RequestBase
    {
        public string UserName { get; set; }
        public int CategoryId { get; set; }
    }
}
