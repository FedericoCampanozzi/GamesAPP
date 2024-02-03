using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
	public interface IOrderService
	{
		Task<List<Order>> GetAllOrder();
		Task<List<Order>> GetOrdersByFilter();
		Task<Order> GetOrderById(int id);
		Task<Order> PutOrder();
		Task<bool> DeleteOrder(int id);
	}
}
