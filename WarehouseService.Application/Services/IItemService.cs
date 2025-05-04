using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Services
{
    public interface IItemService
    {
        Task<IEnumerable<int>> GetItemsFromWarehouse(int warehouseId);
        Task<IEnumerable<int>> GetItemsByCategory(ItemCategory category);
        Task<IEnumerable<int>> GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId);
        Task<bool> UpdateStatus(int itemId, ItemStatus status);
        Task<IEnumerable<int>> GetWithNoWarehouse();
        Task<ItemPresentation> GetItemFullInfo(int itemId);
    }
}
