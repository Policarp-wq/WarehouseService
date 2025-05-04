using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Entities
{
    public class ItemWarehouseLocation
    {
        public int Id { get; set; }
        public string? Sector { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
