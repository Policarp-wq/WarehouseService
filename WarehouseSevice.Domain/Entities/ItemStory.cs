using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Enums;

namespace WarehouseSevice.Domain.Entities
{
    public class ItemStory
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public ItemStatus Status { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
