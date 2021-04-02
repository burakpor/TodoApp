using System.ComponentModel.DataAnnotations;
using TodoApp.Models.EntityModels;

namespace TodoApp.Models.Dtos
{
    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
