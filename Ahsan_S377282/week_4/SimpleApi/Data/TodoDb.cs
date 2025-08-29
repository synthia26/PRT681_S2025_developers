using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Data;

public class Todo
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public bool Done { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
    public DbSet<Todo> Todos => Set<Todo>();
}
