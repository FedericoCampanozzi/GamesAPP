using Bogus;
using GamesAPP.Shared.Data;

namespace GamesAPP.Shared.Entities
{
	public class Warehouse : IEntitySeeder<Warehouse>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		public static Faker<Warehouse> GetEntitySeeder(DataContext _data)
		{
			return new Faker<Warehouse>()
				.RuleFor(e => e.Name, f => f.Company.CompanyName())
				.RuleFor(e => e.Address, f => f.Address.FullAddress());
		}
	}
}
