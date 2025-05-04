using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.Employee
{
    public record EmployeeInfo(string FirstName, string LastName, Position Position, int WarehouseId)
    {
    }
}
