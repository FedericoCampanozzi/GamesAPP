using GamesAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Services
{
	public interface IWarehouseService
	{
		Task<List<Warehouse>> GetAllWarehouses();
		Task<Warehouse> GetWarehouseById(int id);
	}
}
