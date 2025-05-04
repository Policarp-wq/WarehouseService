using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Repositories
{
    public interface IItemRepository
    {
        Task<bool> CreateItem(ItemCreateInfo item);
        Task<bool> UpdateWarehouseId(int itemId, int warehouseId);
        Task<ItemPresentation?> GetById(int itemId);
        Task<IEnumerable<int>> GetItemsFromWarehouse(int warehouseId);
        Task<IEnumerable<ItemPresentation>> GetItemsByCategory(ItemCategory category);
        Task<IEnumerable<ItemPresentation>> GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId);
        Task<bool> UpdateStatus(int itemId, ItemStatus status);
    }
}
