using TaskBoard_Api.Models;
using TaskBoard_Api.Repositories.Interfaces;
using TaskBoard_Api.Services.Interfaces;

namespace TaskBoard_Api.Services
{
    public class TaskService : ITaskService
    {
        public ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            Thread.Sleep(500);
            _taskRepository = taskRepository;
        }

        public TaskItem Create(TaskItem taskItem)
        {
            Thread.Sleep(500);
            return _taskRepository.Create(taskItem);
        }

        public void Delete(int id)
        {
            Thread.Sleep(500);
            _taskRepository.Delete(id);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            Thread.Sleep(500);
            return _taskRepository.GetAll();
        }

        public TaskItem GetById(int id)
        {
            Thread.Sleep(500);
            return _taskRepository.GetById(id);
        }

        public TaskItem Update(int id, TaskItem taskItem)
        {
            Thread.Sleep(500);
            return _taskRepository.Update(id, taskItem);
        }
    }
}
