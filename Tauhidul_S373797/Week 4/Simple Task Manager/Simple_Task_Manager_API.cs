// ==========================================
// API 3: Simple Task Manager API
// Demonstrates CRUD operations with in-memory storage
// ==========================================

using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.Controllers
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        // Simple in-memory storage (not recommended for production)
        private static List<TaskItem> _tasks = new List<TaskItem>();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound(new { Message = "Task not found" });
            
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem newTask)
        {
            if (string.IsNullOrWhiteSpace(newTask.Title))
                return BadRequest(new { Message = "Title is required" });

            newTask.Id = _nextId++;
            newTask.CreatedDate = DateTime.Now;
            _tasks.Add(newTask);

            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask == null)
                return NotFound(new { Message = "Task not found" });

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.IsCompleted = updatedTask.IsCompleted;

            return Ok(existingTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound(new { Message = "Task not found" });

            _tasks.Remove(task);
            return Ok(new { Message = "Task deleted successfully" });
        }
    }
}
