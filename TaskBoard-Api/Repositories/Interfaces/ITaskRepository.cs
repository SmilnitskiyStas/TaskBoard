using TaskBoard_Api.Models;

namespace TaskBoard_Api.Repositories.Interfaces
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
