using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.Employees;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;

namespace WarehouseService.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeePresentation> CreateEmployee(EmployeeInfo employee);
        Task<bool> UpdateAttachedWarehouse(WarehouseWorkUpdateInfo info);
        Task<bool> UpdateAttachedPosition(PositionUpdateInfo info);
        Task<IEnumerable<int>> GetByPosition(Position position);
        Task<int?> GetWarehouseOwner(int warehouseId);
        Task<IEnumerable<int>> GetWarehouseWorkers(int warehouseId);
        Task<IEnumerable<int>> GetWarehouseWorkersByPosition(int warehouseId, Position position);
        Task<EmployeeInfo?> GetById(int id);
    }
}
