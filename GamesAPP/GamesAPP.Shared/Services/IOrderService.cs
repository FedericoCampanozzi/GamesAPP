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
        Task<Order> AddOrder(Order order);
    }
}
