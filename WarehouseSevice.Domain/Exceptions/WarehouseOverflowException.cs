using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Exceptions
{
    public class WarehouseOverflowException : Exception
    {
        public WarehouseOverflowException(int warehouseId) : base($"Overflow in {warehouseId}") { }    
    }
}
