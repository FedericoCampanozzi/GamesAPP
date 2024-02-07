using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
	public interface IWarehouseService
	{
		Task<List<Warehouse>> GetAllWarehouses();
	}
}
