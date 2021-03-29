using System.ComponentModel.DataAnnotations;
using TodoApp.Models.EntityModels;

namespace TodoApp.Models.Dtos
{
    public class UpdateTodoDto
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public TaskStatus TaskStatus { get; set; }
        public int RootTaskId { get; set; }
        [Required]
        public TaskPriority TaskPriority { get; set; }
    }
}
