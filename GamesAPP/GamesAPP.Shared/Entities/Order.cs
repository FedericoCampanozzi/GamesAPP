using Bogus;
using GamesAPP.Shared.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Order: IEntitySeeder<Order>
	{
		public required int Id { get; set; }
		public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public required Product Product { get; set; }
		public required Warehouse? Warehouse { get; set; }
		public required User? UserCreated { get; set; }

		public static Faker<Order> GetEntitySeeder(DataContext _data)
		{
			Random rnd = new Random();
			List<Product> products = _data.Products.ToList<Product>();
			List<Warehouse> warehouses = _data.Warehouses.ToList<Warehouse>();
			List<User> users = _data.MyUsers.ToList<User>();

			Warehouse? w = null;
			User? u = null;
			Product p = products[rnd.Next(products.Count)];

			if (rnd.Next(0, 1) == 0)
				w = warehouses[rnd.Next(warehouses.Count)];
			else
				u = users[rnd.Next(users.Count)];
			
			return new Faker<Order>()
				.RuleFor(e => e.Product, f => f.PickRandom(_data.Products.ToArray()))
				.RuleFor(e => e.Warehouse, f => w)
				.RuleFor(e => e.UserCreated, f => u);
		}
	}
}
