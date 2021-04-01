namespace TodoApp.Models.BusinessModels
{
    public class GetTodoRequest : RequestBase
    {
        public string UserName { get; set; }
        public int TaskId { get; set; }
    }
}
