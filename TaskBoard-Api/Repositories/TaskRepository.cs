using TaskBoard_Api.Models;
using TaskBoard_Api.Repositories.Interfaces;

namespace TaskBoard_Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public IEnumerable<TaskItem> taskItems = new List<TaskItem> {
                new TaskItem {
                    Id = 1,
                    Title = "Sample Task 1",
                    Description = "This is a sample task description.",
                    IsCompleted = false
                },
                new TaskItem {
                    Id = 2,
                    Title = "Sample Task 2",
                    Description = "This is another sample task description.",
                    IsCompleted = true
                },
                new TaskItem {
                    Id = 3,
                    Title = "Sample Task 3",
                    Description = "This is yet another sample task description.",
                    IsCompleted = false
                }
            };

        public TaskItem Create(TaskItem taskItem)
        {
            taskItem.Id = taskItems.Max(t => t.Id) + 1;
            taskItems = taskItems.Append(taskItem);

            return taskItem;
        }

        public void Delete(int id)
        {
            TaskItem taskItem = taskItems.FirstOrDefault(t => t.Id == id);

            if (taskItem != null)
            {
                taskItems = taskItems.Where(t => t.Id != id);
            }
            else
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            taskItems = taskItems.Where(t => t.Id != id);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return taskItems;
        }

        public TaskItem GetById(int id)
        {
            return taskItems.FirstOrDefault(t => t.Id == id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");
        }

        public TaskItem Update(int id, TaskItem taskItem)
        {
            TaskItem existingTaskItem = taskItems.FirstOrDefault(t => t.Id == id);

            if (existingTaskItem != null)
            {
                existingTaskItem.Title = taskItem.Title;
                existingTaskItem.Description = taskItem.Description;
                existingTaskItem.IsCompleted = taskItem.IsCompleted;
                return existingTaskItem;
            }
            else
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
        }
    }
}
