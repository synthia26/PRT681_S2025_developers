// ==========================================
// API 5: User Registration API
// Demonstrates model validation and error handling
// ==========================================

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Controllers
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;
        
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>();
        private static int _nextId = 1;

        [HttpPost("register")]
        public IActionResult Register([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if username already exists
            if (_users.Any(u => u.Username.Equals(newUser.Username, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { Message = "Username already exists" });
            }

            // Check if email already exists
            if (_users.Any(u => u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { Message = "Email already registered" });
            }

            newUser.Id = _nextId++;
            newUser.RegistrationDate = DateTime.Now;
            _users.Add(newUser);

            // Don't return password in response
            var response = new 
            {
                newUser.Id,
                newUser.Username,
                newUser.Email,
                newUser.RegistrationDate,
                newUser.IsActive
            };

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _users.FirstOrDefault(u => 
                u.Username.Equals(loginRequest.Username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == loginRequest.Password && u.IsActive);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            return Ok(new 
            { 
                Message = "Login successful", 
                User = new { user.Id, user.Username, user.Email } 
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound(new { Message = "User not found" });

            var response = new 
            {
                user.Id,
                user.Username,
                user.Email,
                user.RegistrationDate,
                user.IsActive
            };

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _users.Select(u => new 
            {
                u.Id,
                u.Username,
                u.Email,
                u.RegistrationDate,
                u.IsActive
            }).ToList();

            return Ok(users);
        }
    }
}