
// ==========================================
// API 1: Hello World API
// Basic GET endpoint that returns a simple message
// ==========================================

using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult SayHello()
        {
            return Ok(new { Message = "Hello, World!", Timestamp = DateTime.Now });
        }

        [HttpGet("{name}")]
        public IActionResult SayHelloToName(string name)
        {
            return Ok(new { Message = $"Hello, {name}!", Timestamp = DateTime.Now });
        }
    }
}