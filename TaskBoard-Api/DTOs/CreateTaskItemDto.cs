using System.ComponentModel.DataAnnotations;

namespace TaskBoard_Api.DTOs
{
    public class CreateTaskItemDto
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
