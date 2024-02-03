using Bogus;
using GamesAPP.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Warehouse : IEntitySeeder<Warehouse>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		public static Faker<Warehouse> GetEntitySeeder(DataContext _data)
		{
			return new Faker<Warehouse>()
				.RuleFor(e => e.Name, f => f.Company.CompanyName())
				.RuleFor(e => e.Address, f => f.Address.FullAddress());
		}

		public static void DeleteAllItems(DataContext _data)
		{
			var allRecords = _data.Warehouses.ToList();
			_data.Warehouses.RemoveRange(allRecords);
			_data.SaveChanges();
		}
	}
}
