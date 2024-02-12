﻿using GamesAPP.Data;
using GamesAPP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Services
{
	public class WarehouseService : IWarehouseService
	{
		private readonly DataContext _context;

		public WarehouseService(DataContext context)
		{
			_context = context;
		}

		public async Task<Warehouse> GetWarehouseById(int id)
		{
			var warehouse = await _context.Warehouses.FindAsync(id);
			return warehouse;
		}

		async Task<List<Warehouse>> IWarehouseService.GetAllWarehouses()
		{
			var warehouses = await _context.Warehouses.ToListAsync();
			return warehouses;
		}
	}
}