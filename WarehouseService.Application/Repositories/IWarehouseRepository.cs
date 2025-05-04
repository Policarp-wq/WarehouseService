using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Repositories
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> CreateWarehouse(Warehouse warehouse);
        Task<bool> UpdateOwner(int warehouseId, int ownerId);
        Task<bool> DeleteWarehouse(int warehouseId);
    }
}
