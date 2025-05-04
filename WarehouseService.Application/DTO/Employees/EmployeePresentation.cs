using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.DTO.Employees
{
    public record EmployeePresentation(int EmployeeId, string FirstName, string LastName, Position Position, int WarehouseId)
    {
        public static EmployeePresentation FromEntity(Employee employee)
        {
            return new EmployeePresentation(employee.Id, employee.FirstName, employee.LastName, employee.Position, employee.WarehouseId);
        }
    }
}
