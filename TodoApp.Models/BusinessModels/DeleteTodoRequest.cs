namespace TodoApp.Models.BusinessModels
{
    public class DeleteTodoRequest : RequestBase
    {
        public int TodoId { get; set; }
        public string UserName { get; set; }
    }
}
