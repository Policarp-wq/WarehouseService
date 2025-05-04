using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Enums;

namespace WarehouseSevice.Domain.Entities
{
    public class WarehouseShipment
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public DateTime Date {get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public ShipmentAction Action { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

    }
}
