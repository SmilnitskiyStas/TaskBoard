using TaskBoard_Api.Features.Tasks.DTOs;
using TaskBoard_Api.Features.Tasks.Models;

namespace TaskBoard_Api.Features.Tasks.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public IEnumerable<TaskItem> GetAll();
        public TaskItem GetById(int id);
        public TaskItem Create(TaskItem taskItem);
        public TaskItem Update(int id, TaskItem taskItem);
        public void Delete(int id);
    }
}
