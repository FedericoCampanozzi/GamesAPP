using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Post
	{
		public required int Id { get; set; }
		public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public required string Title { get; set; }
		public required string PostText { get; set; }
		public required string PostSummery { get; set; }
		public required User Author { get; set; }
		public required Product Product { get; set; }
	}
}
