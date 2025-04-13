using System.ComponentModel.DataAnnotations;

namespace TaskBoard_Api.Features.Tasks.DTOs
{
    public class CreateTaskItemDto
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
