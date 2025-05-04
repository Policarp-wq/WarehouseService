using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;

namespace WarehouseService.Application.DTO.WarehouseInfo
{
    public record WarehouseInfo(string Address, long Capacity) 
    {
        public static WarehouseInfo FromEntity(Warehouse warehouse)
        {
            return new WarehouseInfo(
                Address: warehouse.Address,
                Capacity: warehouse.Capacity
            );
        }
    }
}
