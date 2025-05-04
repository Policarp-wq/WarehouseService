using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Exceptions
{
    public class NotFoundException : DatabaseException
    {
        public NotFoundException(string table, string message) : base(table, message)
        {

        }
    }
}
