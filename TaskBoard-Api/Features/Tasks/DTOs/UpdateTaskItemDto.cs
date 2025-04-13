using System.ComponentModel.DataAnnotations;

namespace TaskBoard_Api.Features.Tasks.DTOs
{
    public class UpdateTaskItemDto
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(200)] 
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
