using Bogus;
using GamesAPP.Shared.Data;

namespace GamesAPP.Shared.Entities
{
	public class Post : IEntitySeeder<Post>
	{
		public required int Id { get; set; }
		public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public required string Title { get; set; }
		public required string PostText { get; set; }
		public required string PostSummery { get; set; }
		public required User UserCreated { get; set; }
		public required Product Product { get; set; }

		public static Faker<Post> GetEntitySeeder(DataContext _data)
		{
			Random rnd = new Random();
			List<Product> products = _data.Products.ToList<Product>();
			List<User> users = _data.MyUsers.ToList<User>();

			return new Faker<Post>()
				.RuleFor(e => e.Title, f => f.Lorem.Word())
				.RuleFor(e => e.PostText, f => f.Lorem.Text())
				.RuleFor(e => e.PostSummery, f => f.Lorem.Text())
				.RuleFor(e => e.UserCreated, f => users[rnd.Next(users.Count)])
				.RuleFor(e => e.Product, f => products[rnd.Next(products.Count)]);
		}
	}
}
