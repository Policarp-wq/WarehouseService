using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.WarehouseInfo;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseService.Application.Repositories;
using WarehouseService.Infrastructure.Common;
using WarehouseService.Infrastructure.Context;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Repositories
{
    public class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        private readonly DbSet<Warehouse> _warehouses;
        public WarehouseRepository(IDbContext dbContext) : base(dbContext, "Warehouses")
        {
            _warehouses = _dbContext.Warehouses;
        }

        public async Task<WarehousePresentation> CreateWarehouse(WarehouseInfo warehouse)
        {
            var res = _warehouses.Add(new Warehouse
            {
                Address = warehouse.Address,
                Capacity = warehouse.Capacity,
            });
            await _dbContext.SaveChangesAsync();
            return WarehousePresentation.FromEntity(res.Entity);
        }

        public async Task<bool> DeleteWarehouse(int warehouseId)
        {
            await _warehouses
                .Where(x => x.Id == warehouseId)
                .ExecuteDeleteAsync();
            return true;
        }

        public async Task<IEnumerable<WarehousePresentation>> GetAll()
        {
            return await _warehouses
                .AsNoTracking()
                .Select(x => WarehousePresentation.FromEntity(x))
                .ToListAsync();
        }

        public async Task<WarehousePresentation> GetById(int warehouseId)
        {
            var res = await _warehouses
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == warehouseId);
            if(res == null)
                throw new NotFoundException(Table, $"Not found for id {warehouseId}");
            return WarehousePresentation.FromEntity(res);
        }

    }
}
