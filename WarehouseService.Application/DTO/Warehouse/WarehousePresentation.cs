using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.DTO.WarehousePresentation
{
    public record WarehousePresentation(int WarehouseId, string Address, long Capacity)
    {
        public static WarehousePresentation FromEntity(Warehouse warehouse)
        { 
            return new WarehousePresentation(
                WarehouseId: warehouse.Id,
                Address: warehouse.Address,
                Capacity: warehouse.Capacity
            );
        }
    }
}
