
using TaskBoard_Api.Features.Tasks.DTOs;
using TaskBoard_Api.Features.Tasks.Models;
using TaskBoard_Api.Features.Tasks.Repositories.Interfaces;
using TaskBoard_Api.Features.Tasks.Services.Interfaces;

namespace TaskBoard_Api.Features.Tasks.Services
{
    public class TaskService : ITaskService
    {
        public ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            Thread.Sleep(500);
            _taskRepository = taskRepository;
        }

        public TaskItem Create(CreateTaskItemDto createTaskItemDto)
        {
            Thread.Sleep(500);

            TaskItem taskItem = new TaskItem
            {
                Title = createTaskItemDto.Title,
                Description = createTaskItemDto.Description,
                Status = createTaskItemDto.Status,
                Created = createTaskItemDto.Created,
                DueDate = createTaskItemDto.DueDate,
                IsCompleted = createTaskItemDto.IsCompleted,
            };

            return _taskRepository.Create(taskItem);
        }

        public void Delete(int id)
        {
            Thread.Sleep(500);
            _taskRepository.Delete(id);
        }

        public IEnumerable<GetTaskItemDto> GetAll()
        {
            Thread.Sleep(500);
            List<GetTaskItemDto> taskDtos = new List<GetTaskItemDto>();

            var tasks = _taskRepository.GetAll();

            foreach (var task in tasks)
            {
                taskDtos.Add(new GetTaskItemDto
                {
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    Created = task.Created,
                    DueDate = task.DueDate,
                    IsCompleted = task.IsCompleted,
                });
            }

            return taskDtos;
        }

        public GetTaskItemDto GetById(int id)
        {
            Thread.Sleep(500);
            GetTaskItemDto taskDto = new GetTaskItemDto();

            TaskItem taskItem = _taskRepository.GetById(id);

            return new GetTaskItemDto {Title = taskDto.Title, Description = taskDto.Description, Status = taskDto.Status,
                Created = taskDto.Created, DueDate = taskDto.DueDate, IsCompleted = taskDto.IsCompleted };
        }

        public TaskItem Update(int id, UpdateTaskItemDto updateTaskItemDto)
        {
            Thread.Sleep(500);
            TaskItem existingTaskItem = _taskRepository.GetById(id);

            if (existingTaskItem != null)
            {
                existingTaskItem.Title = updateTaskItemDto.Title;
                existingTaskItem.Description = updateTaskItemDto.Description;
                existingTaskItem.Status = updateTaskItemDto.Status;
                existingTaskItem.DueDate = updateTaskItemDto.DueDate;
                existingTaskItem.IsCompleted = updateTaskItemDto.IsCompleted;



                return _taskRepository.Update(id, existingTaskItem);
            }
            else
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
        }
    }
}
