﻿using GamesAPP.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesAPP.Shared.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
	}
}
