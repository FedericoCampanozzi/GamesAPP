using Bogus;
using GamesAPP.Data;
using GamesAPP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GamesAPP
{
	public class DataSeeder
	{
		private readonly DataContext _dbContext;

		public DataSeeder(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void SeedData<T, X>(int nrows)
			where T : IEntitySeeder<X> where X : class
		{
			if (typeof(T) == typeof(X))
			{
				var fakeData = T.GetEntitySeeder(_dbContext).Generate(nrows);
				_dbContext.AddRange(fakeData);
				_dbContext.SaveChanges();
			}
			else
			{
				throw new Exception("T e X devono essere uguali");
			}
		}
	}
}