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
        public int CurrentWarehouseId { get; set; }
        public Warehouse CurrentWarehouse { get; set; } = null!;
        public ItemCategory Category { get; set; }
        public ItemStatus Status { get; set; }
    }
}
