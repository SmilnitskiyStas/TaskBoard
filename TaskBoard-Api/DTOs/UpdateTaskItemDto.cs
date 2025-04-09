using System.ComponentModel.DataAnnotations;

namespace TaskBoard_Api.DTOs
{
    public class UpdateTaskItemDto
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(200)] 
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
