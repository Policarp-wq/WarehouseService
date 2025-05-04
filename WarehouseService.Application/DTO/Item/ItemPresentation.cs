using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.Item
{
    public record ItemPresentation(int ItemId, string Name, ItemSize Size, ItemCategory Category, int WarehouseId)
    {
    }
}
