namespace NotesManagementAPI.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
