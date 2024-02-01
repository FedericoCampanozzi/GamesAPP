using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Warehouse
	{
		public int Id { get; set; }
		public required DateTime CreatedAt { get; set; }
		public required string Name { get; set; }
		public required string Address { get; set; }
		public List<Order> Order { get; set; } = new List<Order>();
	}
}
