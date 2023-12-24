namespace GamesAPP.Shared.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
