using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public long Capacity { get; set; }
        public string Address { get; set; } = null!;
        //public int OwnerId { get; set; }
        //public Employee Owner { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = [];
        public virtual ICollection<Item> Items { get; set; } = [];
    }
}
