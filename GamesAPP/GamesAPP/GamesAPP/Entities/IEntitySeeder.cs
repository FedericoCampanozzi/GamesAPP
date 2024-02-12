using GamesAPP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace GamesAPP.Entities
{
	public interface IEntitySeeder<T> where T : class
	{
		public static abstract Faker<T> GetEntitySeeder(DataContext _data);
		public static abstract void DeleteAllItems(DataContext _data);
	}
}
