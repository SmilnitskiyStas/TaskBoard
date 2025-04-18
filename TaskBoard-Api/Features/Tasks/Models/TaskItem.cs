﻿namespace TaskBoard_Api.Features.Tasks.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
