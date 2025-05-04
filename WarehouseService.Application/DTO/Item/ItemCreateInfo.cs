using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.ItemPresentation
{
    public record ItemCreateInfo(string Name, ItemSize Size, int WarehouseId, ItemCategory Category)
    {
    }
}
