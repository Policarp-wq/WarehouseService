using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Repositories
{
    public interface IItemWarehouseLocationRepository
    {
        Task<bool> ChangeItemLocation(int itemId, string section);
        Task<ItemWarehouseLocation> GetItemLocation(int itemId);
        Task<IEnumerable<ItemWarehouseLocation>> GetWarehouseItemsLocations(int warehouseId);
        Task<IEnumerable<int>> GetNotAllocated(int warehouseId);
    }
}
