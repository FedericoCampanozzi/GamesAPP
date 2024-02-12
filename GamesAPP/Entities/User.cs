using Bogus;
using GamesAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Entities
{
	public class User : IEntitySeeder<User>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;

		public override string ToString()
		{
			return $"User {{Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, UserName: {UserName}}}";
		}

		public static Faker<User> GetEntitySeeder(DataContext _data)
		{
			return new Faker<User>()
				.RuleFor(e => e.FirstName, f => f.Name.FirstName())
				.RuleFor(e => e.LastName, f => f.Name.LastName())
				.RuleFor(e => e.Email, f => f.Internet.Email())
				.RuleFor(e => e.UserName, f => f.Internet.UserName())
				.RuleFor(e => e.Password, f => f.Internet.Password())
				.RuleFor(e => e.Role, f => f.PickRandom("User", "Store", "Administrator"));
		}

		public static void DeleteAllItems(DataContext _data)
		{
			var allRecords = _data.Users.ToList();
			_data.Users.RemoveRange(allRecords);
			_data.SaveChanges();
		}
	}
}
