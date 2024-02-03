﻿using Bogus;
using GamesAPP.Shared.Data;

namespace GamesAPP.Shared.Entities
{
	public class User : IEntitySeeder<User>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;

		public static Faker<User> GetEntitySeeder(DataContext _data)
		{
			return new Faker<User>()
				.RuleFor(e => e.FirstName, f => f.Name.FirstName())
				.RuleFor(e => e.LastName, f => f.Name.LastName())
				.RuleFor(e => e.Email, f => f.Internet.Email())
				.RuleFor(e => e.UserName, f => f.Internet.UserName())
				.RuleFor(e => e.Password, f => f.Internet.Password())
				.RuleFor(e => e.Role, f => f.PickRandom("User","Store","Administrator"));
		}
	}
}