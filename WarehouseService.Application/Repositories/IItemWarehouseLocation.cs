using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Repositories
{
    public interface IItemWarehouseLocation
    {
        Task<bool> ChangeItemLocation(ItemWarehouseLocation itemWarehouseLocation);
        Task<ItemWarehouseLocation> GetItemLocation(int itemId);
        Task<IEnumerable<Item>> GetWarehouseItemsLocations(int warehouseId);
    }
}
