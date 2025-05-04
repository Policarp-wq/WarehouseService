using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseService.Application.DTO.EmployeeInfo;
using WarehouseService.Application.DTO.Employees;
using WarehouseService.Application.Repositories;
using WarehouseService.Application.Services;
using WarehouseSevice.Domain.Entities;
using WarehouseSevice.Domain.Enums;
using WarehouseSevice.Domain.Exceptions;

namespace WarehouseService.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        private async Task<bool> HasOwner(int warehouseId)
        {
            return (await _employeeRepository.GetWarehouseOwner(warehouseId)) != null;
        }

        public async Task<EmployeePresentation> CreateEmployee(EmployeeInfo info)
        {
            if(info.Position == Position.Owner)
                if (await HasOwner(info.WarehouseId))
                    throw new LogicException($"Attemp to create new owner for {info.WarehouseId} which has it already");
            return await _employeeRepository.CreateEmployee(info);
        }
        //TODO: Bad perfomance
        public async Task<bool> UpdatePosition(PositionUpdateInfo info)
        {
            var employee = await _employeeRepository.GetById(info.EmployeeId);
            if(employee == null)
                return false;
            if (info.Position == Position.Owner)
                if (await HasOwner(employee.WarehouseId))
                    throw new LogicException($"Attemp to create new owner for {employee.WarehouseId} which has it already");
            return await _employeeRepository.UpdateAttachedPosition(info);
        }
        //TODO: Bad perfomance
        public async Task<bool> UpdateWarehouseWork(WarehouseWorkUpdateInfo info)
        {
            var employee = await _employeeRepository.GetById(info.EmployeeId);
            if (employee == null)
                return false;
            if (employee.Position == Position.Owner)
                if (await HasOwner(info.WarehouseId))
                    throw new LogicException($"Attemp to create new owner for {info.WarehouseId} which has it already");
            return await _employeeRepository.UpdateAttachedWarehouse(info);
        }
    }
}
