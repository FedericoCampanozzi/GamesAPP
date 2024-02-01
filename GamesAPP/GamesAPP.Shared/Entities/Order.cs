using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public required DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public required Game Game { get; set; }
		public Warehouse? Warehouse { get; set; }
		public required IdentityDbContext? UserCreated { get; set; }
	}
}
