using TaskBoard_Api.Features.Tasks.DTOs;
using TaskBoard_Api.Features.Tasks.Models;

namespace TaskBoard_Api.Features.Tasks.Services.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<GetTaskItemDto> GetAll();
        public GetTaskItemDto GetById(int id);
        public TaskItem Create(CreateTaskItemDto createTaskItemDto);
        public TaskItem Update(int id, UpdateTaskItemDto updateTaskItemDto);
        public void Delete(int id);
    }
}
