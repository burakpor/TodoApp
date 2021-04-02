using System.ComponentModel.DataAnnotations;
using TodoApp.Models.EntityModels;

namespace TodoApp.Models.Dtos
{
    public class AddTodoDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int RootTaskId { get; set; }
        public TaskPriority TaskPriority { get; set; }
    }
}
