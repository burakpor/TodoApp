using TodoApp.Models.EntityModels;

namespace TodoApp.Models.BusinessModels
{
    public class UpdateTodoRequest : RequestBase
    {
        public int TaskId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int RootTaskId { get; set; }
        public TaskPriority TaskPriority { get; set; }
    }
}
