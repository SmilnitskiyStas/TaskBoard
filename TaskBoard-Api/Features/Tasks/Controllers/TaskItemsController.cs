using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoard_Api.Features.Tasks.DTOs;
using TaskBoard_Api.Features.Tasks.Models;
using TaskBoard_Api.Features.Tasks.Services.Interfaces;

namespace TaskBoard_Api.Features.Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        public ITaskService _taskService;

        public TaskItemsController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetTaskItems([FromQuery] string? sort, [FromQuery] string? search, [FromQuery] string? status)
        {
            // This is a placeholder for the actual implementation
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskItemById(int id) 
        {
            var taskItem = _taskService.GetById(id);

            if (taskItem == null)
            {
                return NotFound(new {message = $"Task with id {id} not found"});
            }

            return Ok(taskItem);
        }

        [HttpPost]
        public IActionResult CreateTaskItem([FromBody] CreateTaskItemDto createTaskItemDto)
        {
            if (createTaskItemDto == null)
            {
                return BadRequest("Task item cannot be null.");
            }
            // This is a placeholder for the actual implementation
            TaskItem taskItem = _taskService.Create(createTaskItemDto);

            return CreatedAtAction(nameof(GetTaskItemById), new { id = taskItem.Id}, taskItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskItem(int id, [FromBody] UpdateTaskItemDto updateTaskItemDto)
        {
            if (updateTaskItemDto == null)
            {
                return BadRequest("Task item cannot be null.");
            }

            var existingTaskItem = _taskService.GetById(id);

            if (existingTaskItem == null)
            {
                return NotFound();
            }

            TaskItem taskItem = _taskService.Update(id, updateTaskItemDto);

            return Ok(taskItem);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskItem(int id)
        {
            var taskItem = _taskService.GetById(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            _taskService.Delete(id);

            return NoContent();

        }
    }
}
