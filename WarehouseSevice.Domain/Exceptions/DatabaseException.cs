using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string table, string message) :base($"In table {table}: {message}") { }
    }
}
