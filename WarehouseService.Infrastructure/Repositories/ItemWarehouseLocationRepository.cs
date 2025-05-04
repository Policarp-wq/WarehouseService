using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.Repositories;
using WarehouseService.Infrastructure.Common;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Repositories
{
    public class ItemWarehouseLocationRepository : BaseRepository, IItemWarehouseLocationRepository
    {
        private readonly DbSet<ItemWarehouseLocation> _locations;
        public ItemWarehouseLocationRepository(IDbContext dbContext) : base(dbContext, "WarehouseLocations")
        {
            _locations = _dbContext.ItemsLocations;
        }

        public async Task<bool> ChangeItemLocation(int itemId, string sector)
        {
            var res = await _locations
                .SingleOrDefaultAsync(x => x.ItemId == itemId);
            if (res == null)
                throw new NotFoundException(Table, $"Not found location for item with id {itemId}");
            res.Sector = sector;
            return true;
        }

        public async Task<ItemWarehouseLocation> GetItemLocation(int itemId)
        {
            var res = await _locations
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.ItemId == itemId);
            if (res == null)
                throw new NotFoundException(Table, $"Not found location for item with id {itemId}");
            return res;
        }

        public async Task<IEnumerable<int>> GetNotAllocated(int warehouseId)
        {
            return await _locations
                .AsNoTracking()
                .Where(x => x.Sector == null || x.Sector.Length == 0)
                .Select(x => x.ItemId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemWarehouseLocation>> GetWarehouseItemsLocations(int warehouseId)
        {
            return await _locations
                .Include(x => x.Item)
                .AsNoTracking()
                .Where(x => x.Item.CurrentWarehouseId == warehouseId)
                .ToListAsync();
        }
    }
}
