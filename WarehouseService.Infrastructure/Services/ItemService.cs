using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.Repositories;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Infrastructure.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemPresentation> GetItemFullInfo(int itemId)
        {
            var res = await _repository.GetById(itemId);
            if (res == null)
                throw new ValidationException($"Not found id {itemId}");
            return res;
        }

        public async Task<IEnumerable<ItemPresentation>> GetItemsByCategory(ItemCategory category)
        {
            return await _repository.GetItemsByCategory(category);
        }

        public async Task<IEnumerable<ItemPresentation>> GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId)
        {
            return await _repository.GetItemsByCategoryFromWarehouse(category, warehouseId);
        }

        public async Task<IEnumerable<int>> GetItemsFromWarehouse(int warehouseId)
        {
            return await _repository.GetItemsFromWarehouse(warehouseId);
        }

        public async Task<bool> UpdateStatus(int itemId, ItemStatus status)
        {
            return await _repository.UpdateStatus(itemId, status);
        }
    }
}
