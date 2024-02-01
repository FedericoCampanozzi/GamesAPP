namespace GamesAPP.Shared.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime CreatedAt { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
		public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
		public List<Order> Orders { get; set; } = new List<Order>();
	}
}
