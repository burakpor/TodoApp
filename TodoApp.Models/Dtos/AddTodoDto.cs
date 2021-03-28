using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.Dtos
{
    public class AddTodoDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
