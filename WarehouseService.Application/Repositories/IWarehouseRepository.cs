using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.WarehouseInfo;
using WarehouseService.Application.DTO.WarehousePresentation;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.Repositories
{
    public interface IWarehouseRepository
    {
        Task<WarehousePresentation> CreateWarehouse(WarehouseInfo warehouse);
        Task<IEnumerable<WarehousePresentation>> GetAll();
        Task<WarehousePresentation> GetById(int warehouseId);
        Task<bool> DeleteWarehouse(int warehouseId);
    }
}
