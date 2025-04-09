using TaskBoard_Api.DTOs;
using TaskBoard_Api.Models;

namespace TaskBoard_Api.Services.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<TaskItem> GetAll();
        public TaskItem GetById(int id);
        public TaskItem Create(CreateTaskItemDto createTaskItemDto);
        public TaskItem Update(int id, UpdateTaskItemDto updateTaskItemDto);
        public void Delete(int id);
    }
}
