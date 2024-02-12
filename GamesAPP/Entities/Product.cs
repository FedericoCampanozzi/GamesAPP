using Bogus;
using GamesAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Entities
{
	public class Product: IEntitySeeder<Product>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public static Faker<Product> GetEntitySeeder(DataContext _data)
		{
			return new Faker<Product>()
				.RuleFor(e => e.Name, f => f.Commerce.ProductName())
				.RuleFor(e => e.Description, f => f.Commerce.ProductDescription());
		}

		public static void DeleteAllItems(DataContext _data)
		{
			var allRecords = _data.Products.ToList();
			_data.Products.RemoveRange(allRecords);
			_data.SaveChanges();
		}
	}
}
