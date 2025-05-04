using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Services
{
    public class WarehouseStorageService : IWarehouseStorageService
    {
        private readonly IDatabase _database;
        public WarehouseStorageService(IConnectionMultiplexer multiplexer)
        {
            _database = multiplexer.GetDatabase();
        }
        public async Task<long> AcceptItem(int warehouseId)
        {
            return await _database.StringIncrementAsync(GetTag(warehouseId));
        }
        private string GetTag(int warehouseId) => $"storage:{warehouseId}";

        public async Task<long> GetFullness(int warehouseId)
        {
             if(long.TryParse(await _database.StringGetAsync(GetTag(warehouseId)), out long res))
                return res;
            return 0;
        }

        public async Task<long> ReleaseItem(int warehouseId)
        {
            if (await GetFullness(warehouseId) == 0)
                throw new LogicException($"Warehouse {warehouseId} is empty but attempted to release");
            return await _database.StringDecrementAsync(GetTag(warehouseId));
        }

    }
}
