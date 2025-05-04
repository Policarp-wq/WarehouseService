using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Services
{
    public interface IEmployeeService
    {
        //Check owner
        Task<Employee> CreateEmployee(EmployeeInfo info);
        Task<bool> UpdatePosition(PositionUpdateInfo updateInfo);
        Task<bool> UpdateWarehouseWork(WarehouseWorkUpdateInfo updateInfo);
    }
}
