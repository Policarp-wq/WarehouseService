using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Enums;

namespace WarehouseSevice.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Length { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ItemCategory Category { get; set; }
        public ItemStatus Status { get; set; }
    }
}
