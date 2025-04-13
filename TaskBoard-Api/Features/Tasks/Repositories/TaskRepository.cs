using System.Transactions;
using TaskBoard_Api.Features.Tasks.Data;
using TaskBoard_Api.Features.Tasks.DTOs;
using TaskBoard_Api.Features.Tasks.Models;
using TaskBoard_Api.Features.Tasks.Repositories.Interfaces;

namespace TaskBoard_Api.Features.Tasks.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        //public IEnumerable<TaskItem> taskItems = new List<TaskItem> {
        //        new TaskItem {
        //            Id = 1,
        //            Title = "Sample Task 1",
        //            Description = "This is a sample task description.",
        //            IsCompleted = false
        //        },
        //        new TaskItem {
        //            Id = 2,
        //            Title = "Sample Task 2",
        //            Description = "This is another sample task description.",
        //            IsCompleted = true
        //        },
        //        new TaskItem {
        //            Id = 3,
        //            Title = "Sample Task 3",
        //            Description = "This is yet another sample task description.",
        //            IsCompleted = false
        //        }
        //    };

        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TaskItem Create(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            _context.SaveChanges();

            return taskItem;
        }

        public void Delete(int id)
        {
            TaskItem taskItem = _context.TaskItems.FirstOrDefault(t => t.Id == id);

            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _context.TaskItems;
        }

        public TaskItem GetById(int id)
        {
            return _context.TaskItems.FirstOrDefault(t => t.Id == id) ?? throw new KeyNotFoundException($"Task with ID {id} not found.");
        }

        public TaskItem Update(int id, TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            _context.SaveChanges();

            return taskItem;
        }
    }
}
