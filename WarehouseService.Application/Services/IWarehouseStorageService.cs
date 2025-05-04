using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseService.Application.Services
{
    public interface IWarehouseStorageService
    {
        Task<long> ReleaseItem(int warehouseId);
        Task<long> AcceptItem(int warehouseId);
        Task<long> GetFullness(int warehouseId);
    }
}
