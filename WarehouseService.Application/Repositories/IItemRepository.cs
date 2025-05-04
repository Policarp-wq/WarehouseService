using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Repositories
{
    public interface IItemRepository
    {
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateWarehouseId(int warehouseId);
        Task<IEnumerable<Item>> GetItemsFromWarehouse(int warehouseId);
        Task<IEnumerable<Item>> GetItemsByCategory(ItemCategory category);
        Task<IEnumerable<Item>> GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId);
        Task<bool> UpdateStatus(int itemId, ItemStatus status);
    }
}
