using GamesAPP.Shared.Data;
using GamesAPP.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
	public class WarehouseService : IWarehouseService
	{
		private readonly DataContext _context;

		public WarehouseService(DataContext context)
		{
			_context = context;
		}

		async Task<List<Warehouse>> IWarehouseService.GetAllWarehouses()
		{
			var warehouses = await _context.Warehouses.ToListAsync();
			return warehouses;
		}
	}
}
