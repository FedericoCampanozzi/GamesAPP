using GamesAPP.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesAPP.Shared.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public DbSet<Post> Posts { get; set; }
	}
}
