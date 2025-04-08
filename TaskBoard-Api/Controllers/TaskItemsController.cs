using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBoard_Api.Models;
using TaskBoard_Api.Services.Interfaces;

namespace TaskBoard_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        public ITaskService _taskService;


        [HttpGet]
        public IActionResult GetTaskItems()
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
                return NotFound();
            }

            return Ok(taskItem);
        }

        [HttpPost]
        public IActionResult CreateTaskItem([FromBody] TaskItem taskItem)
        {
            if (taskItem == null)
            {
                return BadRequest("Task item cannot be null.");
            }
            // This is a placeholder for the actual implementation
            taskItem = _taskService.Create(taskItem);

            return Ok(taskItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskItem(int id, [FromBody] TaskItem taskItem)
        {
            if (taskItem == null)
            {
                return BadRequest("Task item cannot be null.");
            }

            var existingTaskItem = _taskService.GetById(id);

            if (existingTaskItem == null)
            {
                return NotFound();
            }

            existingTaskItem.Title = taskItem.Title;
            existingTaskItem.Description = taskItem.Description;
            existingTaskItem.IsCompleted = taskItem.IsCompleted;

            taskItem = _taskService.Update(id, existingTaskItem);

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

            return Ok();

        }
    }
}
