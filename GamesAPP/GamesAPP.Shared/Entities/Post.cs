using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Entities
{
	public class Post
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required DateTime CreatedAt { get; set; }
		public required string PostText { get; set; }
		public required string PostSummery { get; set; }
		public required IdentityDbContext UserCreated { get; set; }
		public required Game Game { get; set; }
	}
}
