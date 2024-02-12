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
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAllOrder()
		{
			var orders = await _context.Orders
                                        .Include(o => o.User)
										.Include(o => o.Product)
										.Include(o => o.Warehouse)
										.ToListAsync();
			return orders;
		}

		async Task<List<Order>> IOrderService.GetAllOrdersFromWarehouse(int id)
		{
            var orders = await _context.Orders
										.Include(o => o.User)
										.Include(o => o.Product)
										.Include(o => o.Warehouse)
				                        .Where(o=> o.Warehouse != null && o.Warehouse.Id == id)
                                        .ToListAsync();
            return orders;
		}
	}
}