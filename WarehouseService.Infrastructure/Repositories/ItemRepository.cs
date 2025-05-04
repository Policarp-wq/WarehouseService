using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.ItemPresentation;
using WarehouseService.Application.Repositories;
using WarehouseService.Infrastructure.Common;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        private readonly DbSet<Item> _items;    
        protected ItemRepository(IDbContext dbContext) : base(dbContext, "Items")
        {
            _items = dbContext.Items;
        }

        public async Task<bool> CreateItem(ItemCreateInfo item)
        {
            _items.Add(new Item
            {
                Name = item.Name,
                Length = item.Size.Length,
                Width = item.Size.Width,
                Height = item.Size.Height,
                CurrentWarehouseId = item.WarehouseId,
                Category = item.Category,
                Status = ItemStatus.Stored,
            });
            return (await _dbContext.SaveChangesAsync()) > 0;

        }

        public async Task<IEnumerable<ItemPresentation>> GetItemsByCategory(ItemCategory category)
        {
            return await _items
                .AsNoTracking()
                .Where(x => x.Category == category)
                .Select(x => ItemPresentation.FromEntity(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemPresentation>> GetItemsByCategoryFromWarehouse(ItemCategory category, int warehouseId)
        {
            return await _items
                .AsNoTracking()
                .Where(x => x.Category == category && x.CurrentWarehouseId == warehouseId)
                .Select(x => ItemPresentation.FromEntity(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<int>> GetItemsFromWarehouse(int warehouseId)
        {
            return await _items
                .AsNoTracking()
                .Where(x => x.CurrentWarehouseId == warehouseId)
                .Select(x => x.Id)
                .ToListAsync();
        }

        public async Task<bool> UpdateStatus(int itemId, ItemStatus status)
        {
            var res = await _items
                .SingleOrDefaultAsync(x => x.Id == itemId);
            if(res == null)
                throw new NotFoundException(Table, $"No item with id {itemId}");
            if(res.Status == status)
                return false;
            res.Status = status;
            return true;
        }

        public async Task<bool> UpdateWarehouseId(int itemId, int warehouseId)
        {
            var res = await _items
                .SingleOrDefaultAsync(x => x.Id == itemId);
            if (res == null)
                throw new NotFoundException(Table, $"No item with id {itemId}");
            if (res.CurrentWarehouseId == warehouseId)
                return false;
            res.CurrentWarehouseId = warehouseId;
            return true;
        }
    }
}
