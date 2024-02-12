using Bogus;
using GamesAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Entities
{
	public class Post: IEntitySeeder<Post>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string Title { get; set; } = string.Empty;
		public string PostText { get; set; } = string.Empty;
		public string PostSummery { get; set; } = string.Empty;
		public required User Author { get; set; }
		public required Product Product { get; set; }

		public static Faker<Post> GetEntitySeeder(DataContext _data)
		{
			return new Faker<Post>()
				.RuleFor(e => e.CreatedAt, f => f.Date.Past(1))
				.RuleFor(e => e.Title, f => f.Lorem.Word())
				.RuleFor(e => e.PostText, f => f.Lorem.Text())
				.RuleFor(e => e.PostSummery, f => f.Lorem.Text())
				.RuleFor(e => e.Author, f => f.PickRandom(_data.Users.ToArray()))
				.RuleFor(e => e.Product, f => f.PickRandom(_data.Products.ToArray()));
		}

		public static void DeleteAllItems(DataContext _data)
		{
			var allRecords = _data.Posts.ToList();
			_data.Posts.RemoveRange(allRecords);
			_data.SaveChanges();
		}
	}
}
