namespace FirstAPI.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Company { get; set; } = null!;

        public int ReleaseYear { get; set; }
    }
}
