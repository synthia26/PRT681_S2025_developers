namespace TodoMvc.Models;

public class Todo
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public bool Done { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
