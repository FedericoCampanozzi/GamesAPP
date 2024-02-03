using Bogus;
using GamesAPP.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Order: IEntitySeeder<Order>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public int Quantity { get; set; } = -1;
		public required Product Product { get; set; }
		public required Warehouse? Warehouse { get; set; }
		public required User? User { get; set; }

		public static Faker<Order> GetEntitySeeder(DataContext _data)
		{
			Random rnd = new Random();

			if (rnd.Next(0, 2) == 0)
				return new Faker<Order>()
					.RuleFor(e => e.CreatedAt, f => f.Date.Past(1))
					.RuleFor(e => e.Quantity, f => rnd.Next(11))
					.RuleFor(e => e.Product, f => f.PickRandom(_data.Products.ToArray()))
					.RuleFor(e => e.Warehouse, f => null)
					.RuleFor(e => e.User, f => f.PickRandom(_data.Users.ToArray()));
			else
				return new Faker<Order>()
					.RuleFor(e => e.Quantity, f => rnd.Next(101))
					.RuleFor(e => e.Product, f => f.PickRandom(_data.Products.ToArray()))
					.RuleFor(e => e.Warehouse, f => f.PickRandom(_data.Warehouses.ToArray()))
					.RuleFor(e => e.User, f => null);
		}

		public static void DeleteAllItems(DataContext _data)
		{
			var allRecords = _data.Orders.ToList();
			_data.Orders.RemoveRange(allRecords);
			_data.SaveChanges();
		}
	}
}
