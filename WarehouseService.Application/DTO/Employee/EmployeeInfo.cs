using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.EmployeeInfo
{
    public record EmployeeInfo(string FirstName, string LastName, Position Position, int WarehouseId)
    {
        public static EmployeeInfo FromEntity(Employee employee)
        {
            return new EmployeeInfo(employee.FirstName, employee.LastName, employee.Position, employee.WarehouseId);
        }
    }
}
