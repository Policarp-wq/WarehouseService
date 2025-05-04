using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.ItemPresentation
{
    public record ItemPresentation(int ItemId, string Name, ItemSize Size, ItemCategory Category, int WarehouseId)
    {
        public static ItemPresentation FromEntity(Item item)
        {
            return new ItemPresentation(
                item.Id,
                item.Name,
                new ItemSize(item.Length, item.Width, item.Height),
                item.Category,
                item.CurrentWarehouseId
            );
        }
    }
}
