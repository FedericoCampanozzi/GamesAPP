using Bogus;
using GamesAPP.Shared.Data;

namespace GamesAPP.Shared.Entities
{
    public class Product: IEntitySeeder<Product>
    {
        public required int Id { get; set; }
		public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
        public List<Post> Posts { get; set; } = new List<Post>();
		public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
		public required List<Order> Orders { get; set; } = new List<Order>();

        public static Faker<Product> GetEntitySeeder(DataContext _data)
        {
            return new Faker<Product>()
                .RuleFor(e => e.Name, f => f.Commerce.ProductName())
                .RuleFor(e => e.Description, f => f.Commerce.ProductDescription());
		}
	}
}
