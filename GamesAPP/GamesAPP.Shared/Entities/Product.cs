using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Product
	{
		public int Id { get; set; } = -1;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}
