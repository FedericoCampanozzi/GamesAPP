using Bogus;
using GamesAPP.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public interface IEntitySeeder<T> where T : class
	{
		public static abstract Faker<T> GetEntitySeeder(DataContext _data);
	}
}
