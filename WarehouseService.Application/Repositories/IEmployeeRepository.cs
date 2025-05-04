using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateAttachedWarehouse(int employeeId, int warehouseId);
        Task<IEnumerable<Employee>> GetByPosition(Position position);
        Task<IEnumerable<Employee>> GetWarehouseOwner(int warehouseId);
        Task<IEnumerable<Employee>> GetWarehouseWorkers(int warehouseId);
        Task<IEnumerable<Employee>> GetWarehouseWorkersByPosition(int warehouseId, Position position);
    }
}
