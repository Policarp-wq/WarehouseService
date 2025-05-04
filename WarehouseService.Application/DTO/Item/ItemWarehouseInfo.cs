using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.ItemPresentation
{
    public record ItemWarehouseInfo(int ItemId, string Location, ItemSize Size, ItemCategory Category, int WarehouseId)
    {
    }
}
