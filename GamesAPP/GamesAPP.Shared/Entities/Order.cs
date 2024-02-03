using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Order
	{
		public required int Id { get; set; }
		public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public required Product Product { get; set; }
		public required Warehouse? Warehouse { get; set; }
		public required User? UserCreated { get; set; }
	}
}
