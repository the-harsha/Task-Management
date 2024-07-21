using Microsoft.AspNetCore.Mvc;
using Task_Management.Services;

namespace Task_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Task>>> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> GetById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Task task)
        {
            await _taskService.AddTaskAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _taskService.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Task>>> GetByUserId(int userId)
        {
            var tasks = await _taskService.GetTasksByUserIdAsync(userId);
            return Ok(tasks);
        }

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<List<Task>>> GetByTeamId(int teamId)
        {
            var tasks = await _taskService.GetTasksByTeamIdAsync(teamId);
            return Ok(tasks);
        }

        [HttpGet("due-in-week")]
        public async Task<ActionResult<List<Task>>> GetTasksDueInWeek()
        {
            var tasks = await _taskService.GetTasksDueInWeekAsync();
            return Ok(tasks);
        }

        [HttpGet("due-in-month")]
        public async Task<ActionResult<List<Task>>> GetTasksDueInMonth()
        {
            var tasks = await _taskService.GetTasksDueInMonthAsync();
            return Ok(tasks);
        }
    }

}
