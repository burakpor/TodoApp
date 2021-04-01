using System.ComponentModel.DataAnnotations;
using TodoApp.Models.EntityModels;

namespace TodoApp.Models.Dtos
{
    public class AddCategoryDto
    {
        [Required]
        public string Category { get; set; }
    }
}
